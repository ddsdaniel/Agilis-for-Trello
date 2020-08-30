using Agilis_for_Trello.Domain.Abstractions.Repositories;
using Agilis_for_Trello.Domain.Abstractions.Services;
using Agilis_for_Trello.Domain.Abstractions.ValueObjects;
using Agilis_for_Trello.Domain.Models.ValueObjects;
using Agilis_for_Trello.Domain.Services;
using Agilis_for_Trello.Infra.Data.Repositories;
using DDS.Domain.Core.Abstractions.Services.Criptografia;
using DDS.Domain.Core.Services.Criptografia;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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
            //Banco de dados
            var mongoDatabase = new MongoClient(new MongoClientSettings { ReplicaSetName = "rs1" }).GetDatabase("agilis-for-trello");
            services.TryAddScoped(x => mongoDatabase);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Usuario
            services.AddTransient<IUsuarioService, UsuarioService>();

            //Seguranca
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<ICriptografiaSimetrica, AdvancedEncryptionStandard>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //AppSettings
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddSingleton<IAppSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value);

            return services;
        }        
    }
}
