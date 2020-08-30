using Agilis_for_Trello.Domain.Models.ValueObjects;
using Bogus;
using DDS.Domain.Core.Model.ValueObjects;
using DDS.Domain.Core.Model.ValueObjects.Seguranca.Senhas;

namespace Agilis_for_Trello.Domain.Mocks.ValueObjects
{
    public static class LoginMock
    {
        public static Login ObterValido()
        {
            return new Faker<Login>()
               .CustomInstantiator(p => new Login(EmailMock.ObterValido(),
                                                  SenhaMock.ObterValida()
                                                  ))
               .Generate();
        }

        public static Login ObterComSenha(SenhaMedia senha)
        {
            return new Faker<Login>()
               .CustomInstantiator(p => new Login(EmailMock.ObterValido(),
                                                  senha
                                                  ))
               .Generate();
        }

        public static Login ObterComEmail(Email email)
        {
            return new Faker<Login>()
               .CustomInstantiator(p => new Login(email,
                                                  SenhaMock.ObterValida()
                                                  ))
               .Generate();
        }
    }
}
