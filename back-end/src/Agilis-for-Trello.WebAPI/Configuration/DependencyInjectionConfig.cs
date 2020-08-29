using Agilis_for_Trello.Domain.Abstractions.ValueObjects;
using Agilis_for_Trello.Domain.Models.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Agilis_for_Trello.WebAPI.Configuration
{
    /// <summary>
    /// Dependency injections configuration class
    /// </summary>
    public static class DependencyInjectionConfig
    {

        /// <summary>
        /// Configure dependency injections
        /// </summary>
        /// <param name="services">Startup services collection</param>
        /// <param name="configuration">Application configuration properties</param>
        /// <returns>Updated services</returns>
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //AppSettings
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddSingleton<IAppSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value);

            return services;
        }        
    }
}
