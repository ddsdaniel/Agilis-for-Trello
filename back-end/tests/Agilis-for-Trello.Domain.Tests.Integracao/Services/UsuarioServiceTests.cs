using Agilis_for_Trello.Domain.Abstractions.Repositories;
using Agilis_for_Trello.Domain.Mocks.Entities;
using Agilis_for_Trello.Domain.Mocks.ValueObjects;
using Agilis_for_Trello.Domain.Services;
using AutoMoqCore;
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
    }
}
