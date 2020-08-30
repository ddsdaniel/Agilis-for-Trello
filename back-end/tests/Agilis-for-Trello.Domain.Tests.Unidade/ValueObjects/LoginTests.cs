using Agilis_for_Trello.Domain.Mocks.ValueObjects;
using Agilis_for_Trello.Domain.Models.Entities;
using DDS.Domain.Core.Model.ValueObjects;
using DDS.Domain.Core.Model.ValueObjects.Seguranca.Senhas;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Agilis_for_Trello.Domain.Tests.Unidade.ValueObjects
{
    public class LoginTests
    {
        [Fact]
        public void Construtor_DadosValidos_Valid()
        {
            //Arrange & Act
            var login = LoginMock.ObterValido();

            //Assert
            Assert.True(login.Valid);
        }

        [Fact]
        public void Construtor_SenhaNula_Invalid()
        {
            //Arrange & Act
            var login = LoginMock.ObterComSenha(null);

            //Assert
            Assert.True(login.Invalid);
        }

        [Fact]
        public void Construtor_SenhaInvalida_Invalid()
        {
            //Arrange & Act
            var login = LoginMock.ObterComSenha(new SenhaMedia(null, Usuario.TAMANHO_MINIMO_SENHA));

            //Assert
            Assert.True(login.Invalid);
        }

        [Fact]
        public void Construtor_EmailNulo_Invalid()
        {
            //Arrange & Act
            var login = LoginMock.ObterComEmail(null);

            //Assert
            Assert.True(login.Invalid);
        }

        [Fact]
        public void Construtor_EmailInvalido_Invalid()
        {
            //Arrange & Act
            var login = LoginMock.ObterComEmail(new Email(null));

            //Assert
            Assert.True(login.Invalid);
        }
    }
}
