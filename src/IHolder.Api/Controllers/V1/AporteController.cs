using System;
using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using IHolder.Application.Queries;
using IHolder.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AporteController : ResponseBaseController
    {
        private readonly IAporteQueries _aporteQueries;
        private readonly IUser _user;

        public AporteController(IMediator mediator, INotificationHandler<Notification> notifications, IAporteQueries aporteQueries, IUser user)
            : base(mediator, notifications)
        {
            _aporteQueries = aporteQueries;
            _user = user;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Insert(CadastrarAporteCommand command)
        {
            await _mediator.Send(command);
            return ResponseBase("Aporte cadastrado com sucesso");
        }



        [HttpPut("alterar/{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult> Alterar(Guid id, AlterarAporteCommand command)
        {
                    if (id != command?.Id)
            {
                NotifyError("O ID do registro informado para alteração está inválido.");
                return ResponseBase();
            }
            await _mediator.Send(command);
            return ResponseBase("Registro alterado com sucesso");
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<ActionResult> ObterAportes()
        {
            return ResponseBase(await _aporteQueries.ObterAportesPorUsuario(_user.GetUserId()));
        }
    
    }
}
