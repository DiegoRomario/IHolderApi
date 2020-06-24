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
    public class AtivoEmCarteiraController : ResponseBaseController
    {
        private readonly IAtivoEmCarteiraQueries _ativoEmCarteiraQueries;
        private readonly IUser _user;

        public AtivoEmCarteiraController(IMediator mediator, INotificationHandler<Notification> notifications, IAtivoEmCarteiraQueries ativoEmCarteiraQueries, IUser user)
            : base(mediator, notifications)
        {
            _ativoEmCarteiraQueries = ativoEmCarteiraQueries;
            _user = user;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Insert(CadastrarAtivoEmCarteiraCommand command)
        {
            await _mediator.Send(command);
            return ResponseBase("Ativo cadastrado na carteira com sucesso");
        }



        [HttpPut("alterar/{id:guid}")]
        public async Task<ActionResult> Alterar(Guid id, AlterarAtivoEmCarteiraCommand command)
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
        public async Task<ActionResult> ObterAtivosEmCarteira()
        {
            return ResponseBase(await _ativoEmCarteiraQueries.ObterAtivosEmCarteiraPorUsuario(_user.GetUserId()));
        }

    }
}
