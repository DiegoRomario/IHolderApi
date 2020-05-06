using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IHolder.Api.Configurations;
using IHolder.Api.Controllers.Base;
using IHolder.Api.ViewModels;
using IHolder.Business.Entities;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : ResponseBaseController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AppSettings _appSettings;
        public UsuarioController(INotifier notifier,
            IMapper mapper,
            IUsuarioService usuarioService,
            IOptions<AppSettings> appSettings,
            IUser user) : base(notifier, mapper, user)
        {
            _usuarioService = usuarioService;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("entrar")]
        public async Task<ActionResult<Usuario_resposta_autenticacaoViewModel>> Login([FromBody] Usuario_autenticacaoViewModel usuario_autenticacao)
        {
            if (!ModelState.IsValid) return ResponseBase(ModelState);

            var usuario = _mapper.Map<UsuarioViewModel>(_usuarioService.GetBy(u => u.Email.ToUpper() == usuario_autenticacao.Login.ToLower() &&
                               u.Senha == usuario_autenticacao.Password).Result);

            if (usuario == null)
            {
                NotifyError("Usuário ou senha inválidos");
                return ResponseBase(usuario);
            }

            Usuario_resposta_autenticacaoViewModel usuarioAutenticado = await GenerateToken(usuario);
            return ResponseBase(usuarioAutenticado);
        }
        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<ActionResult<UsuarioViewModel>> Insert ([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid) 
                return ResponseBase(ModelState);
            await _usuarioService.Insert(_mapper.Map<Usuario>(model));
            model.Senha = string.Empty;
            return ResponseBase(model);
        }

        [HttpPut("alterar/{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Update(Guid id, UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(ModelState);
            if (id != model.Id)
            {
                NotifyError("O ID do registro informado para alteração está inválido.");
                return ResponseBase(null);
            }
            await _usuarioService.Update(_mapper.Map<Usuario>(model));
            model.Senha = string.Empty;
            return ResponseBase(model);
        }

        private async Task<Usuario_resposta_autenticacaoViewModel> GenerateToken(UsuarioViewModel user)
        {
            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Nome.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Chave);
            DateTime Expires_in = DateTime.UtcNow.AddHours(_appSettings.Expiracao_horas);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.Valido_em,
                Subject = new ClaimsIdentity(claims),
                Expires = Expires_in,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string encodedToken = tokenHandler.WriteToken(token);

            var response = new Usuario_resposta_autenticacaoViewModel()
            {
                Nome = user.Nome,
                Token = encodedToken,
                Expira_em = Expires_in,
                Email = user.Email
            };
            return await Task.FromResult(response);
        }


    }
}