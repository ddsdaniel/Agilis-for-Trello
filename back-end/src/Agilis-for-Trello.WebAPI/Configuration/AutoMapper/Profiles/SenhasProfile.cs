using Agilis_for_Trello.Domain.Models.Entities;
using AutoMapper;
using DDS.Domain.Core.Models.ValueObjects.Seguranca.Senhas;

namespace Agilis_for_Trello.WebAPI.Configuration.AutoMapper.Profiles
{
    public class SenhasProfile : Profile
    {
        public SenhasProfile()
        {
            CreateMap<SenhaMedia, string>()
              .ConvertUsing(senha => senha.Conteudo);

            CreateMap<string, SenhaMedia>()
                .ConstructUsing(senha => new SenhaMedia(senha, Usuario.TAMANHO_MINIMO_SENHA));
        }
    }
}
