using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace Agilis_for_Trello.WebAPI.Configuration
{
    /// <summary>
    /// Extensions class for Swagger settings
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Configures the Open Api Info, XML version and path data
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors</param>
        /// <returns>Updated services</returns>
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                     new OpenApiInfo()
                     {
                         Title = "API - Agilis for Trello",
                         Description = "Agile metrics based on data from your Trello boards",
                         Version = PlatformServices.Default.Application.ApplicationVersion,
                         Contact = new OpenApiContact() { Name = "Daniel Dorneles da Silva", Email = "dds.daniel@gmail.com" },
                         License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                     });

                if (!environment.IsStaging())
                {
                    string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                    string applicationName = PlatformServices.Default.Application.ApplicationName;
                    string xmlDocFile = Path.Combine(applicationPath, $"{applicationName}.xml");

                    c.IncludeXmlComments(xmlDocFile);
                }
            });

            return services;
        }

        /// <summary>
        /// Enables the use of Swagger and defines its Endpoint
        /// </summary>
        /// <param name="app">Defines a class that provides the mechanisms to configure an application's request pipeline</param>
        /// <returns>Updated app</returns>
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agilis for Trello");
            });

            return app;
        }
    }
}
