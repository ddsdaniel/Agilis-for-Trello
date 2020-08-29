using DDS.Domain.Core.Abstractions.Services;
using DDS.Domain.Core.Model.ValueObjects;
using DDS.Domain.Core.Model.ValueObjects.Senhas;
using System;
using System.Threading.Tasks;
using Agilis_for_Trello.Domain.Models.Entities;
using Agilis_for_Trello.Domain.Models.ValueObjects;

namespace Agilis_for_Trello.Domain.Abstractions.Services
{
    public interface IUsuarioService : ICrudService<Usuario>
    {
        public Usuario Autenticar(Login login);
        public Task AlterarSenha(Guid id, Email emailLogado, SenhaMedia senhaAtual, SenhaMedia novaSenha, SenhaMedia confirmaNovaSenha);
        public Usuario ConsultarPorEmail(Email email);
    }
}
