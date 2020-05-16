using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHolder.Application.Queries;
using MediatR;
using IHolder.Application.Commands;
using IHolder.Application.Base;
using IHolder.Application.ViewModels;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : ResponseBaseController
    {
        private readonly IUsuarioQueries _usuarioQueries;
        public UsuarioController(IUsuarioQueries usuarioQueries, IMediator mediator, INotificationHandler<Notification> notification) : base(mediator, notification)
        {
            _usuarioQueries = usuarioQueries;
        }

        [AllowAnonymous]
        [HttpPost("entrar")]
        public async Task<ActionResult> Login([FromBody] UsuarioLoginArgs login)
        {
            UsuarioAutenticadoViewModel usuario = await _usuarioQueries.AutenticarUsuario(login);

            if (usuario != null)
                return ResponseBase(usuario);

            NotifyError("Usuario e/ou senha invalidos");
            return ResponseBase();
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<ActionResult> Insert([FromBody] CadastrarUsuarioCommand model)
        {
            return ResponseBase(await _mediator.Send(model) ? "Usuario cadastrado com sucesso" : null);
        }

    }
}