using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.Core;
using backEnd.Actors.Messages;
using backEnd.Actors.RemoveActors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using backEnd.Models;
using backEnd.Models.UploadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Internal;
using backEnd.Controllers.UploadImagesControllers;
using CloudinaryDotNet;

namespace backEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)//, IHostingEnvironment env)
        {
            Configuration = configuration;
            //HostingEnvironment = env;
            //Console.WriteLine(env.WebRootPath);

        }

        public IConfiguration Configuration { get; }
        //public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settingsSection = Configuration.GetSection("AppIdentitySettings");
            var settings = settingsSection.Get<AppIdentitySettings>();

            services.AddCors(options =>
            {
                //options.AddPolicy("AllowSpecificOrigin", builder =>
                //{
                //    builder.WithOrigins("http://localhost", "https://www.microsoft.com");
                //});

                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                    // or use below code 
                });
            });

            services.AddDbContext<PaintStoreContext>(options =>
                options.UseSqlite("Data Source=PaintStore.db"));
            //services.AddDbContext<PaintStoreContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("PaintStoreDatabase")));

            services.AddSingleton<ISaveImage, SaveImage>();
            services.AddScoped<RemoveSupervisorActor>();
            services.AddScoped<RemoveAccountActor>();
            // Inject AppIdentitySettings so that others can use too
            var system = ActorSystem.Create("PSActorSystem");

            services.AddSingleton<ActorSystem>(system);
            services.AddTransient<Account>(s => new Account(settings.CouldName, settings.ApiKey, settings.SecretApiKey));
            services.AddMvc().AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).AddControllersAsServices();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");

            app.UseMvc();
        }

    }
}
