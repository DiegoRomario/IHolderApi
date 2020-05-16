using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHolder.Application.Queries;
using MediatR;
using IHolder.Application.Commands;
using IHolder.Application.Base;

namespace IHolder.Api.Controllers.V1
{
    //[Authorize]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //public class UsuarioController : ResponseBaseController
    //{
        //private readonly IUsuarioQueries _usuarioQueries;
        //private readonly IMediator mediator;
        //public UsuarioController(IUsuarioQueries usuarioQueries, IMediator mediatr) 
        //{
            
        //    _usuarioQueries = usuarioQueries;
        //    mediator = mediatr;
        //}
        //[AllowAnonymous]
        //[HttpPost("entrar")]
        //public async Task<ActionResult> Login([FromBody] UsuarioLoginArgs login)
        //{
        //    return ResponseBase(await _usuarioQueries.AutenticarUsuario(login));
        //}
        //[AllowAnonymous]
        //[HttpPost("cadastrar")]
        //public async Task<ActionResult> Insert ([FromBody] CadastrarUsuarioCommand model)
        //{
        //    return ResponseBase(await mediator.Send(model));
        //}

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

    //}
}