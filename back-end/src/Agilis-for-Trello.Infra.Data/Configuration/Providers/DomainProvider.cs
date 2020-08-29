using DDS.Domain.Core.Model.ValueObjects.Senhas;
using MongoDB.Bson.Serialization;
using System;
using DDS.Domain.Core.Abstractions.Services.Criptografia;
using Agilis_for_Trello.Domain.Abstractions.ValueObjects;
using Agilis_for_Trello.Infra.Data.Configuration.Serializers;

namespace Agilis_for_Trello.Infra.Data.Configuration.Providers
{
    public class DomainProvider : IBsonSerializationProvider
    {
        private readonly ICriptografiaSimetrica _criptografiaSimetrica;
        private readonly IAppSettings _appSettings;

        public DomainProvider(ICriptografiaSimetrica criptografiaSimetrica, IAppSettings appSettings)
        {
            _criptografiaSimetrica = criptografiaSimetrica;
            _appSettings = appSettings;
        }

        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(SenhaMedia))
            {
                return new SenhaMediaSerializer(_criptografiaSimetrica, _appSettings);
            }

            return null;
        }
    }
}
