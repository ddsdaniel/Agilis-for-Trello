using Agilis_for_Trello.Domain.Abstractions.Repositories;
using Agilis_for_Trello.Domain.Mocks.Entities;
using Agilis_for_Trello.Domain.Mocks.ValueObjects;
using Agilis_for_Trello.Domain.Models.Entities;
using Agilis_for_Trello.Domain.Services;
using AutoMoqCore;
using DDS.Domain.Core.Models.ValueObjects.Seguranca.Senhas;
using System.Threading.Tasks;
using Xunit;

namespace Agilis_for_Trello.Domain.Tests.Integracao.Services
{
    public class UsuarioServiceTests
    {
        [Fact]
        public void Autenticar_DadosCorretos_Valid()
        {
            //Arrange
            var mocker = new AutoMoqer();
            var login = LoginMock.ObterValido();
            var usuarioMock = UsuarioMock.ObterComEmail(login.Email, login.Senha);

            mocker.GetMock<IUnitOfWork>()
                  .Setup(uow => uow.UsuarioRepository.ConsultarPorEmail(login.Email))
                  .Returns(usuarioMock);

            var unitOfWork = mocker.GetMock<IUnitOfWork>().Object;

            var usuarioService = new UsuarioService(unitOfWork);

            //Act
            var usuario = usuarioService.Autenticar(login);

            //Assert
            Assert.NotNull(usuario);
            Assert.True(login.Valid);
            Assert.True(usuarioService.Valid);
            Assert.Equal(login.Email.Endereco, usuario.Email.Endereco);
            Assert.Equal(login.Senha.Conteudo, usuario.Senha.Conteudo);
        }

        [Fact]
        public void Autenticar_LoginInvalido_Invalid()
        {
            //Arrange
            var mocker = new AutoMoqer();
            var login = LoginMock.ObterInvalido();
            var usuarioMock = UsuarioMock.ObterComEmail(login.Email, login.Senha);

            mocker.GetMock<IUnitOfWork>()
                  .Setup(uow => uow.UsuarioRepository.ConsultarPorEmail(login.Email))
                  .Returns(usuarioMock);

            var unitOfWork = mocker.GetMock<IUnitOfWork>().Object;

            var usuarioService = new UsuarioService(unitOfWork);

            //Act
            var usuario = usuarioService.Autenticar(login);

            //Assert
            Assert.Null(usuario);
            Assert.True(login.Invalid);
            Assert.True(usuarioService.Invalid);
        }

        [Fact]
        public void Autenticar_SenhaIncorreta_Invalid()
        {
            //Arrange
            var mocker = new AutoMoqer();
            var login = LoginMock.ObterValido();
            var senhaDiferente = new SenhaMedia(login.Senha + "_diferente", Usuario.TAMANHO_MINIMO_SENHA);
            var usuarioMock = UsuarioMock.ObterComEmail(login.Email, senhaDiferente);

            mocker.GetMock<IUnitOfWork>()
                  .Setup(uow => uow.UsuarioRepository.ConsultarPorEmail(login.Email))
                  .Returns(usuarioMock);

            var unitOfWork = mocker.GetMock<IUnitOfWork>().Object;

            var usuarioService = new UsuarioService(unitOfWork);

            //Act
            var usuario = usuarioService.Autenticar(login);

            //Assert
            Assert.Null(usuario);
            Assert.True(login.Valid);
            Assert.True(usuarioService.Invalid);
        }

        [Fact]
        public async void AlterarSenha_DadosCorretos_Valid()
        {
            //Arrange
            var mocker = new AutoMoqer();
            var novaSenha = SenhaMock.ObterValida();
            var confirmaSenha = novaSenha;
            var usuarioMock = UsuarioMock.ObterComEmail(EmailMock.ObterValido(), SenhaMock.ObterValida());

            mocker.GetMock<IUnitOfWork>()
                  .Setup(uow => uow.UsuarioRepository.ConsultarPorId(usuarioMock.Id))
                  .Returns(new Task<Usuario>(() => usuarioMock));

            var unitOfWork = mocker.GetMock<IUnitOfWork>().Object;

            var usuarioService = new UsuarioService(unitOfWork);

            //Act
            await usuarioService.AlterarSenha(usuarioMock.Id, usuarioMock.Email, usuarioMock.Senha, novaSenha, confirmaSenha);

            //Assert
            Assert.True(usuarioService.Valid);
        }

    }
}
