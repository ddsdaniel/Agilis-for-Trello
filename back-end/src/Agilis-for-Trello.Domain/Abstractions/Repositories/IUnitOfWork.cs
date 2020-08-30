using Agilis_for_Trello.Domain.Abstractions.Repositories;
using System.Threading.Tasks;

namespace Agilis_for_Trello.Domain.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        Task Commit();
    }
}
