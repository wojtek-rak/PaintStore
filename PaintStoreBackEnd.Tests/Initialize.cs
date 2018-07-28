using backEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PaintStoreBackEnd.Tests
{
    public class Initialize
    {
        //private IServiceProvider serviceProvider;
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return config;
        }
        //public static PaintStoreContext GetContext()        //Microsoft.EntityFrameworkCore.DbContextOptions<PaintStoreContext>
        //{

        //    var container = new Container();
        //    container.Configure(config =>
        //    {
        //        // Register stuff in container, using the StructureMap APIs...
        //        config.Scan(_ =>
        //        {
        //            _.AssemblyContainingType(typeof(Program));
        //            _.WithDefaultConventions();
        //        });
        //        // Populate the container using the service collection
        //        config.Populate(services);
        //    });

        //    var serviceProvider = container.GetInstance<IServiceProvider>();







        //    var config = InitConfiguration();

        //    //var options = serviceProvider.GetService<DbContextOptions<BloggingContext>>();
        //    var services = new ServiceCollection();
        //    services
        //        .AddDbContext<PaintStoreContext>(options =>
        //        options.UseSqlServer(config.GetConnectionString("PaintStoreDatabase")));

        //    var serviceProvider = services.BuildServiceProvider();
        //    return serviceProvider.GetRequiredService<PaintStoreContext>();
        //}
        public static string GetConnectionString()
        {
            var config = InitConfiguration();
            return config.GetConnectionString("PaintStoreDatabase");
        }
    }
}
