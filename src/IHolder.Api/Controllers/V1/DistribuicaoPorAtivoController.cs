using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IHolder.Application.Base;
using System.Collections.Generic;
using IHolder.Application.Queries;
using IHolder.Application.Commands;
using System;
using System.Threading;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistribuicaoPorAtivoController : ResponseBaseController
    {
        private readonly IDistribuicaoPorAtivoQueries _distribuicaoPorAtivoQueries;

        public DistribuicaoPorAtivoController(IMediator mediator,
            IDistribuicaoPorAtivoQueries distribuicaoPorAtivoQueries,
            INotificationHandler<Notification> notificationHandler) : base(mediator, notificationHandler)
        {
            _distribuicaoPorAtivoQueries = distribuicaoPorAtivoQueries;
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Alterar(Guid id, AlterarDistribuicaoPorAtivoCommand command)
        {
            if (id != command.Id)
            {
                NotifyError("O ID do registro informado para alteração está inválido.");
                return ResponseBase();
            }
            await _mediator.Send(command);
            return ResponseBase("Percentual objetivo atualizado com sucesso.");

        }

        [HttpGet]
        public async Task<ActionResult> ObterDistribuicoesPorAtivo()
        {
            IEnumerable<DistribuicaoViewModel> distribuicoes
                = await _distribuicaoPorAtivoQueries.ObterDistribuicaoPorAtivo();
            return ResponseBase(distribuicoes);
        }

        [HttpPost("recalcular")]
        public async Task<ActionResult> Recalcular()
        {
            await _mediator.Send(new RecalcularDistribuicaoPorAtivoCommand());
            return ResponseBase("Recalculo efetuado com sucesso");
        }

        [HttpPost("dividir")]
        public async Task<ActionResult> Dividir(DividirDistribuicaoPorAtivoCommand command)
        {
            await _mediator.Send(command);
            return ResponseBase("Percentuais divididos igualmente entre ativos" + (command.SomenteItensEmCarteira ? " em carteira" : " cadastrados"));
        }

    }
}