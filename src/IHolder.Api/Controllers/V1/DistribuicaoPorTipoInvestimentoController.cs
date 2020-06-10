using System;
using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IHolder.Application.Commands;
using IHolder.Application.Base;
using IHolder.Application.Queries;
using System.Collections.Generic;
namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistribuicaoPorTipoInvestimentoController : ResponseBaseController
    {
        private readonly IDistribuicaoPorTipoInvestimentoQueries _distribuicaoPorTipoInvestimentoQueries;

        public DistribuicaoPorTipoInvestimentoController(IMediator mediator,
            IDistribuicaoPorTipoInvestimentoQueries distribuicaoPorTipoInvestimentoQueries,
            INotificationHandler<Notification> notificationHandler) : base(mediator, notificationHandler)
        {
            _distribuicaoPorTipoInvestimentoQueries = distribuicaoPorTipoInvestimentoQueries;
        }


        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult> Alterar(Guid id, AlterarDistribuicaoPorTipoInvestimentoCommand command)
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
        public async Task<ActionResult> ObterDistribuicoesPorTipoInvestimento()
        {
            IEnumerable<DistribuicaoViewModel> distribuicoes
                = await _distribuicaoPorTipoInvestimentoQueries.ObterDistribuicaoPorTipoInvestimento();
            return ResponseBase(distribuicoes);
        }

        [HttpPost("recalcular")]
        public async Task<ActionResult> Recalcular()
        {
            await _mediator.Send(new RecalcularDistribuicaoPorTipoInvestimentoCommand());
            return ResponseBase("Recalculo efetuado com sucesso");
        }

        [HttpPost("dividir")]
        public async Task<ActionResult> Dividir(DividirDistribuicaoPorTipoInvestimentoCommand command)
        {
            await _mediator.Send(command);
            return ResponseBase("Percentuais divididos igualmente entre tipos de investimentos" + (command.SomenteItensEmCarteira ? " em carteira" : " cadastrados"));
        }

    }
}