using Agilis_for_Trello.Domain.Models.Entities;
using Agilis_for_Trello.Domain.Models.ValueObjects;
using Agilis_for_Trello.WebAPI.ViewModels;
using AutoMapper;
using DDS.Domain.Core.Model.ValueObjects;
using DDS.Domain.Core.Model.ValueObjects.Senhas;

namespace Agilis_for_Trello.WebAPI.Configuration.AutoMapper.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<LoginViewModel, Login>()
                .ConstructUsing((vm, context) =>
                    new Login(
                        email: new Email(vm.Email),
                        senha: new SenhaMedia(vm.Senha, Usuario.TAMANHO_MINIMO_SENHA)
                        )
                 );

            CreateMap<Usuario, UsuarioConsultaViewModel>();

            CreateMap<UsuarioCadastroViewModel, Usuario>()
                 .ConstructUsing((vm, context) =>
                    new Usuario(
                        email: new Email(vm.Email),
                        nome: vm.Nome,
                        sobrenome: vm.Sobrenome,
                        senha: new SenhaMedia(vm.Senha, Usuario.TAMANHO_MINIMO_SENHA),
                        regra: vm.Regra
                        )
                 );
        }
    }
}