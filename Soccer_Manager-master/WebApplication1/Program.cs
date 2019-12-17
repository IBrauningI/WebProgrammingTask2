using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using DAL;
using DAL.Initializers;
using Microsoft.AspNetCore.Identity;
using DAL.Model_Classes;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
