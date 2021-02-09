using Agilis_for_Trello.Domain.Enums;
using DDS.Domain.Core.Models.ValueObjects;
using DDS.Domain.Core.Models.ValueObjects.Seguranca.Senhas;
using System;

namespace Agilis_for_Trello.Domain.Abstractions.Entities
{
    public interface IUsuario
    {
        Guid Id { get; }
        DateTime DataCriacao { get; }
        DateTime DataUltimaAlteracao { get; }
        Email Email { get; }
        string Nome { get; }
        RegraUsuario Regra { get; }
        SenhaMedia Senha { get; }
        string Sobrenome { get; }
    }
}