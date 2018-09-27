using System.IO;
using CoreplusExercise.Accessor.Practitioner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreplusExercise.Accessor.Practitioner.DependencyInjection;
using CoreplusExercise.Accessor;
using CoreplusExercise.Managers.Practitioner.DependencyInjection;
using CoreplusExercise.Accessor.Mock.DependencyInjection;

namespace CoreplusExercise.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PractitionerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            string basePath = PlatformServices.Default.Application.ApplicationBasePath;
            string xmlPath = Path.Combine(basePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");

            services.AddMvc();

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "CoreplusExercise API", Version = "v1" });
                    c.IncludeXmlComments(xmlPath);
                });

            services.AddAutoMapper();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<MockAccessorModule>();
            builder.RegisterModule<PractitionerAccessorModule>();
            builder.RegisterModule<PractitionerManagerModule>();
            
            ApiAutofacContainer.Container = AccessorAutofacContainer.Container = builder.Build();

            return new AutofacServiceProvider(ApiAutofacContainer.Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreplusExercise API v1");
            });

            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => AccessorAutofacContainer.Container.Dispose());
            appLifetime.ApplicationStopped.Register(() => ApiAutofacContainer.Container.Dispose());
        }
    }
}
