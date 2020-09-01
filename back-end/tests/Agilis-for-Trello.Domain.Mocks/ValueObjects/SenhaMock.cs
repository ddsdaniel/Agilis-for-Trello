using Agilis_for_Trello.Domain.Models.Entities;
using Bogus;
using DDS.Domain.Core.Model.ValueObjects.Seguranca.Senhas;

namespace Agilis_for_Trello.Domain.Mocks.ValueObjects
{
    public static class SenhaMock
    {
        public static SenhaMedia ObterValida()
        {
            return new Faker<SenhaMedia>()
                .CustomInstantiator(s => new SenhaMedia(s.Internet.Password(Usuario.TAMANHO_MINIMO_SENHA,
                                                                            false,
                                                                            "\\w",
                                                                            "1a@"),
                                                        Usuario.TAMANHO_MINIMO_SENHA))
                .Generate();
        }

        public static SenhaMedia ObterInvalida()
        {
            return new SenhaMedia("123", 8);
        }

    }
}
