using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IHolder.Application.Base;
using System.Collections.Generic;
using IHolder.Domain.DomainObjects;
using IHolder.Application.Queries.Distribuicoes;
using IHolder.Application.Commands;
using System;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistribuicaoPorAtivoController : ResponseBaseController
    {
        private readonly IUser _user;
        private readonly IDistribuicaoPorAtivoQueries _distribuicaoPorAtivoQueries;

        public DistribuicaoPorAtivoController(IMediator mediator,
            IDistribuicaoPorAtivoQueries distribuicaoPorAtivoQueries,
            INotificationHandler<Notification> notificationHandler, IUser user) : base(mediator, notificationHandler)
        {
            _distribuicaoPorAtivoQueries = distribuicaoPorAtivoQueries;
            _user = user;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar([FromBody] CadastrarDistribuicaoPorAtivoCommand command)
        {
            var teste = await _mediator.Send(command);
            return ResponseBase("Distribuição cadastrada com sucesso");
        }

        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult> Alterar(Guid id, AlterarDistribuicaoPorAtivoCommand command)
        {
            if (id != command.Id)
            {
                NotifyError("O ID do registro informado para alteração está inválido.");
                return ResponseBase();
            }

            return ResponseBase(await _mediator.Send(command));

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ObterDistribuicoesPorAtivo()
        {
            IEnumerable<DistribuicaoPorAtivoViewModel> distribuicoes
                = await _distribuicaoPorAtivoQueries.ObterDistribuicaoPorAtivo();
            return ResponseBase(distribuicoes);
        }

        [HttpPost("recalcular")]
        public async Task<ActionResult> Recalcular()
        {
            return ResponseBase(await _mediator.Send(new RecalcularDistribuicaoPorAtivoCommand(_user.GetUserId())));
        }

    }
}