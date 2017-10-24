using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreModule2.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }
    public class Greeter : IGreeter
    {
        private string greeting;
        public Greeter(IConfiguration configuration)
        {
            greeting = configuration["Welcome"];
        }
        public string GetGreeting()
        {
            return greeting;
        }
    }
}
