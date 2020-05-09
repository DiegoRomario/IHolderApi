using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IHolder.Api.Configurations;
using IHolder.Api.Controllers.Base;
using IHolder.Api.ViewModels;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using IHolder.Business.Queries;
using IHolder.Business.ViewModels;
using MediatR;
using IHolder.Business.Commands;
using IHolder.Business.Base;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : ResponseBaseController
    {
        private readonly AppSettings _appSettings;
        private readonly IUsuarioQueries _usuarioQueries;
        private readonly IMediator _mediatr;
        public UsuarioController(INotifier notifier,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IUser user, IUsuarioQueries usuarioQueries, IMediator mediatr) : base(notifier, mapper, user)
        {
            _appSettings = appSettings.Value;
            _usuarioQueries = usuarioQueries;
            _mediatr = mediatr;
        }
        [AllowAnonymous]
        [HttpPost("entrar")]
        public async Task<ActionResult<Usuario_resposta_autenticacaoViewModel>> Login([FromBody] UsuarioLoginArgs login)
        {
            if (!ModelState.IsValid) return ResponseBase(ModelState);

            UsuarioAutenticadoViewModel usuario = await _usuarioQueries.AutenticarUsuario(login);

            if (usuario == null)
            {
                NotifyError("Usuário e/ou senha inválidos");
                return ResponseBase();
            }

            GerarToken(usuario);

            return ResponseBase();
        }
        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<ActionResult<UsuarioViewModel>> Insert ([FromBody] CadastrarUsuarioCommand model)
        {
            Response response = await _mediatr.Send(model);
            return ResponseBase(response);
        }

        //[HttpPut("alterar/{id:guid}")]
        //public async Task<ActionResult<UsuarioViewModel>> Update(Guid id, UsuarioViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return ResponseBase(ModelState);
        //    if (id != model.Id)
        //    {
        //        NotifyError("O ID do registro informado para alteração está inválido.");
        //        return ResponseBase(null);
        //    }
        //    await _usuarioService.Update(_mapper.Map<Usuario>(model));
        //    model.Senha = string.Empty;
        //    return ResponseBase(model);
        //}

        private void GerarToken(UsuarioAutenticadoViewModel usuario)
        {
            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email.ToString()),
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Chave);
            DateTime ExpiresIn = DateTime.UtcNow.AddHours(_appSettings.Expiracao_horas);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.Valido_em,
                Subject = new ClaimsIdentity(claims),
                Expires = ExpiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string encodedToken = tokenHandler.WriteToken(token);

            usuario.Token = encodedToken;

       }


    }
}