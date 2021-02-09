using Agilis_for_Trello.Domain.Models.ValueObjects;
using Bogus;
using DDS.Domain.Core.Models.ValueObjects;
using DDS.Domain.Core.Models.ValueObjects.Seguranca.Senhas;

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

        public static Login ObterInvalido()
        {
            return new Login(EmailMock.ObterInvalido(),
                             SenhaMock.ObterInvalida()
                            );
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
