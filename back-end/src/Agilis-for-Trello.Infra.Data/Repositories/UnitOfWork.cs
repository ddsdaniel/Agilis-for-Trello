using MongoDB.Driver;
using Agilis_for_Trello.Domain.Abstractions.Repositories;
using System;
using System.Threading.Tasks;

namespace Agilis_for_Trello.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IClientSessionHandle _session;
        private bool _disposed = false;
        public IUsuarioRepository UsuarioRepository { get; }

        public UnitOfWork(IMongoDatabase database)
        {
            _session = database.Client.StartSession();
            _session.StartTransaction();

            UsuarioRepository = new UsuarioRepository(database, _session);
        }

        public async Task Commit()
        {
            if (_session.IsInTransaction)
                await _session.CommitTransactionAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                try
                {
                    if (_session.IsInTransaction)
                        _session.AbortTransaction();

                    _session.Dispose();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            _disposed = true;
        }
    }
}
