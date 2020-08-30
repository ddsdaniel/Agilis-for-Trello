using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Agilis_for_Trello.WebAPI.Configuration.AutoMapper.Profiles;
using DDS.WebAPI.Configuration.AutoMapper.Profiles;

namespace Agilis_for_Trello.WebAPI.Configuration.AutoMapper
{
    /// <summary>
    /// Define o mapeamento entre as entidades e as view models, bem como alguns value objects específicos
    /// </summary>
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddSingleton((provider) => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmailProfile>();
                cfg.AddProfile<SenhasProfile>();
                cfg.AddProfile<UsuariosProfile>();
            }).CreateMapper());

            return services;
        }
    }
}