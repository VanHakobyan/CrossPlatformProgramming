using System;

namespace DoubleInterfaceTest.Services
{
    public class ServiceA : IService
    {
        public void M()
        {
            Console.WriteLine("A");
        }
    }
}
