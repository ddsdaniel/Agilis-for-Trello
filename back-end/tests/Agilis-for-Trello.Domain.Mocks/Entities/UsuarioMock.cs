using Bogus;
using Agilis_for_Trello.Domain.Models.Entities;
using Agilis_for_Trello.Domain.Mocks.ValueObjects;
using Agilis_for_Trello.Domain.Enums;
using DDS.Domain.Core.Model.ValueObjects.Seguranca.Senhas;

namespace Agilis_for_Trello.Domain.Mocks.Entities
{
    public static class UsuarioMock
    {
        public static Usuario ObterValido()
        {
            return new Faker<Usuario>()
               .CustomInstantiator(p => new Usuario(EmailMock.ObterValido(),
                                                    p.Person.FirstName,
                                                    p.Person.LastName,
                                                    SenhaMock.ObterValida(),
                                                    p.PickRandom<RegraUsuario>()
                                                    ))
               .Generate();
        }

        public static Usuario ObterInvalido()
        {
            return new Usuario(null,
                           null,
                           null,
                           null,
                           RegraUsuario.Usuario
                           );
        }

        public static Usuario ObterAdminValido()
        {
            return new Faker<Usuario>()
             .CustomInstantiator(p => new Usuario(EmailMock.ObterValido(),
                                                  p.Person.FirstName,
                                                  p.Person.LastName,
                                                  SenhaMock.ObterValida(),
                                                  RegraUsuario.Admin
                                                  ))
             .Generate();
        }

        public static Usuario ObterComNome(string nome)
        {
            return new Faker<Usuario>()
            .CustomInstantiator(p => new Usuario(EmailMock.ObterValido(),
                                                 nome,
                                                 p.Person.LastName,
                                                 SenhaMock.ObterValida(),
                                                 RegraUsuario.Admin
                                                 ))
            .Generate();
        }

        public static Usuario ObterComSobrenome(string sobrenome)
        {
            return new Faker<Usuario>()
            .CustomInstantiator(p => new Usuario(EmailMock.ObterValido(),
                                                 p.Person.FirstName,
                                                 sobrenome,
                                                 SenhaMock.ObterValida(),
                                                 RegraUsuario.Admin
                                                 ))
            .Generate();
        }

        public static Usuario ObterComSenha(SenhaMedia senha)
        {
            return new Faker<Usuario>()
            .CustomInstantiator(p => new Usuario(EmailMock.ObterValido(),
                                                 p.Person.FirstName,
                                                 p.Person.LastName,
                                                 senha,
                                                 RegraUsuario.Admin
                                                 ))
            .Generate();
        }
    }
}
