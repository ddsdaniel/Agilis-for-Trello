using Agilis_for_Trello.Domain.Abstractions.Services;
using Agilis_for_Trello.Domain.Abstractions.ValueObjects;
using Agilis_for_Trello.Domain.Models.Entities;
using DDS.Domain.Core.Abstractions.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agilis_for_Trello.Domain.Services
{
    public class TokenService: Service, ITokenService
    {
        private readonly IAppSettings _appSettings;

        public TokenService(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Gera um token baseado no usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string Gerar(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Segredo);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email.Endereco),
                    new Claim(ClaimTypes.Role, usuario.Regra.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
