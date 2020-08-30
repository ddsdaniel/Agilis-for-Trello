﻿using DDS.Domain.Core.Abstractions.Model.ValueObjects;
using DDS.Domain.Core.Model.ValueObjects;
using DDS.Domain.Core.Model.ValueObjects.Seguranca.Senhas;
using Flunt.Validations;
using DDS.Domain.Core.Extensions;

namespace Agilis_for_Trello.Domain.Models.ValueObjects
{
    public class Login : ValueObject<Login>
    {
        public Email Email { get; private set; }
        public SenhaMedia Senha { get; private set; }

        protected Login()
        {

        }

        public Login(Email email, SenhaMedia senha)
        {
            AddNotifications(new Contract()
                .IsNotNull(email, nameof(Email), "E-mail não deve ser nulo")
                .IsNotNull(senha, nameof(Senha), "Senha não deve ser nula")
                );

            this.AddNotificationsIfNotNull(email, senha);

            Email = email;
            Senha = senha;
        }
    }
}
