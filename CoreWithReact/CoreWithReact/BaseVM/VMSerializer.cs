﻿/* 
Copyright 2017 Dicky Suryadi

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using Newtonsoft.Json;

namespace DotNetify
{
   /// <summary>
   /// Base class for all DotNetify view models.  
   /// </summary>
   public class VMSerializer : ISerializer, IDeserializer
   {
      /// <summary>
      /// Serializes a view model into JSON-formatted string.
      /// </summary>
      /// <param name="viewModel">View model to serialize.</param>
      /// <param name="ignoredPropertyNames">Names of properties that are not be serialized.</param>
      /// <returns>Serialized view model.</returns>
      public string Serialize(object viewModel, List<string> ignoredPropertyNames)
      {
         try
         {
            return JsonConvert.SerializeObject(viewModel, new JsonSerializerSettings { ContractResolver = new VMContractResolver(ignoredPropertyNames) });
         }
         catch (Exception ex)
         {
            Trace.Fail(ex.ToString());
            return string.Empty;
         }
      }

      /// <summary>
      /// Deserializes a property value of a view model.
      /// </summary>
      /// <param name="viewModel">View model to deserialize the property to.</param>
      /// <param name="vmPath">View model property path.</param>
      /// <param name="newValue">New value.</param>
      /// <returns>True if the value was deserialized.</returns>
      public bool Deserialize(object viewModel, string vmPath, string newValue)
      {
         try
         {
            var vmType = viewModel.GetType();
            var path = vmPath.Split('.');
            for (int i = 0; i < path.Length; i++)
            {
               var propName = path[i];
               var propInfo = vmType.GetTypeInfo().GetProperty(propName);
               if (propInfo == null)
                  return false;

               var propType = propInfo.PropertyType.GetTypeInfo();

               if (i < path.Length - 1)
               {
                  // Path that starts with $ sign means it is a key to an IEnumerable property.
                  // By convention we expect a method whose name is in this format:
                  // <IEnumerable property name>_get (for example: ListContent_get) 
                  // to get the object whose key matches the given value in the path.
                  if (path[i + 1].StartsWith("$"))
                  {
                     var key = path[i + 1].TrimStart('$');
                     var methodInfo = vmType.GetTypeInfo().GetMethod(propName + "_get");
                     if (methodInfo == null)
                        return false;

                     viewModel = methodInfo.Invoke(viewModel, new object[] { key });
                     if (viewModel == null)
                        return false;

                     vmType = viewModel.GetType();
                     i++;
                  }
                  else
                  {
                     viewModel = propInfo.GetValue(viewModel);
                     vmType = viewModel != null ? viewModel.GetType() : propInfo.PropertyType;
                  }
               }
               else if (typeof(ICommand).GetTypeInfo().IsAssignableFrom(propInfo.PropertyType) && viewModel != null)
               {
                  // If the property type is ICommand, execute the command.
                  (propInfo.GetValue(viewModel) as ICommand)?.Execute(newValue);
               }
               else if (propType.IsSubclassOf(typeof(MulticastDelegate)) && propType.GetMethod(nameof(Action.Invoke)).ReturnType == typeof(void))
               {
                  // If the property type is Action, wrap the action in a Command object and execute it.
                  var argTypes = propType.GetGenericArguments();
                  var cmdType = argTypes.Length > 0 ? typeof(Command<>).MakeGenericType(argTypes) : typeof(Command);
                  (Activator.CreateInstance(cmdType, new object[] { propInfo.GetValue(viewModel) }) as ICommand)?.Execute(newValue);
               }
               else if (propInfo.SetMethod != null && viewModel != null)
               {
                  // Update the new value to the property.
                  if (propType.IsClass && propInfo.PropertyType != typeof(string))
                     propInfo.SetValue(viewModel, JsonConvert.DeserializeObject(newValue, propInfo.PropertyType));
                  else
                  {
                     var typeConverter = TypeDescriptor.GetConverter(propInfo.PropertyType);
                     if (typeConverter != null)
                        propInfo.SetValue(viewModel, typeConverter.ConvertFromString(newValue));
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Trace.Fail(ex.ToString());
            return false;
         }

         return true;
      }
   }
}
