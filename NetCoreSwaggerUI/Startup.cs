using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetCoreSwaggerUI.Business.Abstract;
using NetCoreSwaggerUI.Business.Concrete;
using NetCoreSwaggerUI.DataAccess.Abstract;
using NetCoreSwaggerUI.DataAccess.Concrete;

namespace NetCoreSwaggerUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddSwaggerGen(i =>
            {
                i.SwaggerDoc("CoreSwagger",new OpenApiInfo
                {
                    Title = "Swagger Net Core",
                    Description = "Net core 3.1",
                    Version = "2.0.0",
                    Contact = new OpenApiContact()
                    {
                        Name = "Swagger Implementation Deniz",
                        Email = "deneme@hotmail.com",
                        Url = new Uri("http://denizturkmen.com.tr")
                    },
                    TermsOfService = new Uri("http://swagger.io/terms/")
                });
            });
            
            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //options.IncludeXmlComments(xmlPath);


            services.AddScoped<IPersonService, PersonManager>();
            services.AddScoped<IPersonDal, EfCorePersonDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger().UseSwaggerUI(i =>
            {
                i.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger Test Net Core");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
