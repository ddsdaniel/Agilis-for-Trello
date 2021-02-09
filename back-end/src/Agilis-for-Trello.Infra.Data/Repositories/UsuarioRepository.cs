using DDS.Domain.Core.Models.ValueObjects;
using DDS.Infra.Data.Mongo.Abstractions.Repositories;
using MongoDB.Driver;
using System.Linq;
using Agilis_for_Trello.Domain.Models.Entities;
using Agilis_for_Trello.Domain.Abstractions.Repositories;

namespace Agilis_for_Trello.Infra.Data.Repositories
{
    public class UsuarioRepository : MongoRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IMongoDatabase mongoDatabase, IClientSessionHandle session = null) 
            : base(mongoDatabase, session)
        {
        }

        public Usuario ConsultarPorEmail(Email email)
        {
            return AsQueryable()
                .Where(u => u.Email.Endereco == email.Endereco)
                .FirstOrDefault();
        }
    }
}
