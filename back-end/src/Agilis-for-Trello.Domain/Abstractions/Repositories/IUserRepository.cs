using DDS.Domain.Core.Abstractions.Repositories;
using DDS.Domain.Core.Model.ValueObjects;
using Agilis_for_Trello.Domain.Models.Entities;

namespace Agilis_for_Trello.Domain.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<Usuario>
    {        
        public Usuario ConsultarPorEmail(Email email);
    }
}
