using Agilis_for_Trello.Domain.Abstractions.Services;
using Agilis_for_Trello.Domain.Models.ValueObjects;
using Agilis_for_Trello.WebAPI.ViewModels;
using AutoMapper;
using DDS.WebAPI.Abstractions.Controllers;
using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agilis_for_Trello.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : GenericController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Construtor completo da Controller
        /// </summary>
        /// <param name="mapper">Automapper</param>
        /// <param name="usuarioService">Serviço para validação e manipulação da entidade</param>
        /// <param name="tokenService">Serviço que gera o token da autenticação do usuário</param>
        public AutenticacaoController(IMapper mapper,
                                      IUsuarioService usuarioService,
                                      ITokenService tokenService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Realiza a autenticação do usuário
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns>Dados do usuário + token da autenticação</returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UsuarioLogadoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notification>), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] LoginViewModel loginViewModel)
        {
            var login = _mapper.Map<Login>(loginViewModel);

            var usuario = _usuarioService.Autenticar(login);

            if (_usuarioService.Invalid)
                return BadRequest(_usuarioService.Notifications);

            var token = _tokenService.Gerar(usuario);

            var usuarioLogado = _mapper.Map<UsuarioConsultaViewModel>(usuario);

            return Ok(new UsuarioLogadoViewModel
            {
                Usuario = usuarioLogado,
                Token = token,
                TipoToken = "Bearer"
            });
        }
    }
}
