using Agilis_for_Trello.Domain.Models.Entities;

namespace Agilis_for_Trello.Domain.Abstractions.Services
{
    public interface ITokenService
    {
        string Gerar(Usuario usuario);
    }
}
