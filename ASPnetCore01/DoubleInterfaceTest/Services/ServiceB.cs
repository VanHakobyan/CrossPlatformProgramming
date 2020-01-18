using System;

namespace DoubleInterfaceTest.Services
{
    public class ServiceB : IService
    {
        public void M()
        {
            Console.WriteLine("B");
        }
    }
}
