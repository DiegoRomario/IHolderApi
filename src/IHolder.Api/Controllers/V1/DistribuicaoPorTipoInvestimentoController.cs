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
using IHolder.Application.ViewModels;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistribuicaoPorTipoInvestimentoController : ResponseBaseController
    {
        private readonly IMediator _mediator;
        private readonly IDistribuicaoPorTipoInvestimentoQueries _distribuicaoPorTipoInvestimentoQueries;

        public DistribuicaoPorTipoInvestimentoController(IMediator mediator,
            IDistribuicaoPorTipoInvestimentoQueries distribuicaoPorTipoInvestimentoQueries,
            INotificationHandler<Notification> notificationHandler) : base(mediator, notificationHandler)
        {
            _mediator = mediator;
            _distribuicaoPorTipoInvestimentoQueries = distribuicaoPorTipoInvestimentoQueries;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar([FromBody]CadastrarDistribuicaoPorTipoInvestimentoCommand command)
        {
            bool test = await _mediator.Send(command);
            return ResponseBase("Distribuição cadastrada com sucesso");

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
            else
            {
                return ResponseBase(await _mediator.Send(command));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ObterDistribuicoesPorTipoInvestimento()
        {
            IEnumerable<DistribuicaoPorTipoInvestimentoViewModel> distribuicoes
                = await _distribuicaoPorTipoInvestimentoQueries.ObterDistribuicaoPorTipoInvestimento();
            return ResponseBase(distribuicoes);
        }

        [HttpPost("recalcular")]
        public async Task<ActionResult> Recalcular()
        {
            return ResponseBase(await _mediator.Send(new RecalcularDistribuicaoPorTipoInvestimentoCommand(new Guid("EC1C63CE-5733-47B5-860C-23D7E62660E7"))));
        }

    }
}