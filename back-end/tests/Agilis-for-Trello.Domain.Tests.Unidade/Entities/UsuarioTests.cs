using DDS.Domain.Core.Model.ValueObjects.Seguranca.Senhas;
using Xunit;
using Agilis_for_Trello.Domain.Mocks.Entities;
using Agilis_for_Trello.Domain.Models.Entities;

namespace Agilis_for_Trello.Domain.Tests.Unidade.Entities
{
    public class UsuarioTests
    {
        [Fact]
        public void Construtor_DadosValidos_Valid()
        {
            //Arrange & Act
            var usuario = UsuarioMock.ObterValido();

            //Assert
            Assert.True(usuario.Valid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Construtor_NomeInvalido_Invalid(string nome)
        {
            //Arrange & Act
            var usuario = UsuarioMock.ObterComNome(nome);

            //Assert
            Assert.True(usuario.Invalid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Construtor_SobrenomeInvalido_Invalid(string sobrenome)
        {
            //Arrange & Act
            var usuario = UsuarioMock.ObterComSobrenome(sobrenome);

            //Assert
            Assert.True(usuario.Invalid);
        }

        [Fact]
        public void Construtor_SenhaNula_Invalid()
        {
            //Arrange & Act
            var usuario = UsuarioMock.ObterComSenha(null);

            //Assert
            Assert.True(usuario.Invalid);
        }

        [Fact]
        public void Construtor_SenhaInvalida_Invalid()
        {
            //Arrange & Act
            var usuario = UsuarioMock.ObterComSenha(new SenhaMedia(null, Usuario.TAMANHO_MINIMO_SENHA));

            //Assert
            Assert.True(usuario.Invalid);
        }

        [Fact]
        public void AlterarSenha_DadosValidos_SenhaAlterada()
        {
            //Arrange
            var usuario = UsuarioMock.ObterValido();
            var novaSenha = new SenhaMedia("abc123%¨&*(", Usuario.TAMANHO_MINIMO_SENHA);

            //Act
            usuario.AlterarSenha(usuario.Senha, novaSenha, novaSenha);

            //Assert
            Assert.True(usuario.Valid);
            Assert.Equal(novaSenha.Conteudo, usuario.Senha.Conteudo);
        }

        [Fact]
        public void AlterarSenha_ErroSenhaAtual_NaoAlterarSenha()
        {
            //Arrange
            var usuario = UsuarioMock.ObterValido();
            var novaSenha = new SenhaMedia("abc123%¨&*(", Usuario.TAMANHO_MINIMO_SENHA);
            var senhaAtualErrada = new SenhaMedia("abc123%¨&*(", Usuario.TAMANHO_MINIMO_SENHA);

            //Act
            usuario.AlterarSenha(senhaAtualErrada, novaSenha, novaSenha);

            //Assert
            Assert.True(usuario.Invalid);
            Assert.NotEqual(novaSenha.Conteudo, usuario.Senha.Conteudo);
        }

        [Fact]
        public void AlterarSenha_SenhasNaoConferem_NaoAlterarSenha()
        {
            //Arrange
            var usuario = UsuarioMock.ObterValido();
            var novaSenha = new SenhaMedia("abc123%¨&*(", Usuario.TAMANHO_MINIMO_SENHA);
            var confirmaSenha = new SenhaMedia("abc12345678", Usuario.TAMANHO_MINIMO_SENHA);

            //Act
            usuario.AlterarSenha(usuario.Senha, novaSenha, confirmaSenha);

            //Assert
            Assert.True(usuario.Invalid);
            Assert.NotEqual(novaSenha.Conteudo, usuario.Senha.Conteudo);
        }

        [Fact]
        public void AlterarSenha_NovaSenhaInvalida_NaoAlterarSenha()
        {
            //Arrange
            var usuario = UsuarioMock.ObterValido();
            var novaSenha = new SenhaMedia("123", Usuario.TAMANHO_MINIMO_SENHA);

            //Act
            usuario.AlterarSenha(usuario.Senha, novaSenha, novaSenha);

            //Assert
            Assert.True(usuario.Invalid);
            Assert.NotEqual(novaSenha.Conteudo, usuario.Senha.Conteudo);
        }
    }
}
