using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Akka.Util.Internal;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using backEnd.Actors;
using backEnd.Actors.Messages;
using backEnd.Actors.RemoveActors;
using backEnd.Actors.Services;
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
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    var settingsSection = Configuration.GetSection("AppIdentitySettings");
        //    var settings = settingsSection.Get<AppIdentitySettings>();

        //    services.AddCors(options =>
        //    {
        //        //options.AddPolicy("AllowSpecificOrigin", builder =>
        //        //{
        //        //    builder.WithOrigins("http://localhost", "https://www.microsoft.com");
        //        //});

        //        options.AddPolicy("AllowAllOrigins", builder =>
        //        {
        //            builder.AllowAnyOrigin();
        //            builder.AllowAnyHeader();
        //            builder.AllowAnyMethod();
        //            builder.AllowCredentials();
        //            // or use below code 
        //        });
        //    });

        //    services.AddDbContext<PaintStoreContext>(options =>
        //        options.UseSqlite("Data Source=PaintStore.db"));
        //    //services.AddDbContext<PaintStoreContext>(options =>
        //    //    options.UseSqlServer(Configuration.GetConnectionString("PaintStoreDatabase")));

        //    services.AddSingleton<ISaveImage, SaveImage>();
        //    services.AddScoped<RemoveSupervisorActor>();
        //    services.AddScoped<RemoveAccountActor>();
        //    // Inject AppIdentitySettings so that others can use too
        //    var system = ActorSystem.Create("PSActorSystem");

        //    services.AddSingleton<ActorSystem>(system);
        //    services.AddTransient<Account>(s => new Account(settings.CouldName, settings.ApiKey, settings.SecretApiKey));
        //    services.AddMvc().AddJsonOptions(
        //    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //    ).AddControllersAsServices();


        //}

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var settingsSection = Configuration.GetSection("AppIdentitySettings");
            var settings = settingsSection.Get<AppIdentitySettings>();

            services.AddCors(options =>
            {
                //options.AddPolicy("AllowSpecificOrigin", builder =>
                //{
                //    builder.WithOrigins("http://localhost", "https://www.microsoft.com");
                //});

                options.AddPolicy("AllowAllOrigins", build =>
                {
                    build.AllowAnyOrigin();
                    build.AllowAnyHeader();
                    build.AllowAnyMethod();
                    build.AllowCredentials();
                    // or use below code 
                });
            });

            services.AddSingleton<IActivityManagerStartup, ActivityManager>();
            services.AddMvc().AddControllersAsServices();
            services.AddDbContext<PaintStoreContext>(options =>
                options.UseSqlite("Data Source=PaintStore.db"));
            
            
            //Now register our services with Autofac container

            PaintStoreContext dbContext;
            var scopeFactory = services
                .BuildServiceProvider()
                .GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var db = provider.GetRequiredService<PaintStoreContext>())
                {
                    dbContext = db;
                }
            }
            var builder = new ContainerBuilder();

            //builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();
            var actorSystem = ActorSystem.Create("PSActorSystem");
            builder.Register<ActorSystem>(_ => actorSystem);
            //var dbContext = services.OfType<PaintStoreContext>();
            //var actorRemove = actorSystem.ActorOf(Props.Create(() => new RemoveAccountImagesActor()));
            //var actorActivityManager
            var actorActivity = actorSystem.ActorOf(Props.Create(() => new ActivityActor()));
            var actorSupervisor = actorSystem.ActorOf(Props.Create(() => new SupervisorActor(actorActivity)));
            builder.Register<IActorRef>(c => actorSupervisor);
            builder.Populate(services);
            var container = builder.Build();


            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IActivityManagerStartup activityManager, IServiceScopeFactory _scopeFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            activityManager.RunManager();

            app.UseCors("AllowAllOrigins");

            app.UseMvc();
        }

    }
}
