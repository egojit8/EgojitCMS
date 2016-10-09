using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using EgojitCms.web.Models;

namespace EgojitCms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var context = new EgojitCmsDbContext())
            //{
            //    // Create database
            //    context.Database.EnsureCreated();
            //    var user = new User { Id = Guid.NewGuid(), Name = "Yuuko" };
            //    context.Add(user);
            //}
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
            
        }
    }
}
