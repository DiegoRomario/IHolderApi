using System;
using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IHolder.Application.Commands;
using IHolder.Application.Base;
using IHolder.Application.Queries;
using System.Threading;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistribuicaoPorTipoInvestimentoController : ResponseBaseController
    {
        private readonly IMediator _mediator;
        private readonly IResponse _response;
        private readonly IDistribuicaoPorTipoInvestimentoQueries _distribuicaoPorTipoInvestimentoQueries;

        public DistribuicaoPorTipoInvestimentoController(IMediator mediator, IResponse response, IDistribuicaoPorTipoInvestimentoQueries distribuicaoPorTipoInvestimentoQueries)
        {
            _mediator = mediator;
            _response = response;
            _distribuicaoPorTipoInvestimentoQueries = distribuicaoPorTipoInvestimentoQueries;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar([FromBody]CadastrarDistribuicaoPorTipoInvestimentoCommand command)
        { 
            return ResponseBase(await _mediator.Send(command));
        }

        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult> Alterar(Guid id, AlterarDistribuicaoPorTipoInvestimentoCommand command)
        {
            if (id != command.Id)            
                return ResponseBase(_response.Error("O ID do registro informado para alteração está inválido."));
            else
                return ResponseBase(await _mediator.Send(command));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ObterDistribuicoesPorTipoInvestimento()
        {
            return ResponseBase(await _distribuicaoPorTipoInvestimentoQueries.ObterDistribuicaoPorTipoInvestimento());
        }

        [HttpPost("recalcular")]
        public async Task<ActionResult> Recalcular()
        {

            return ResponseBase(await _mediator.Send(new RecalcularDistribuicaoPorTipoInvestimentoCommand(new Guid("EC1C63CE-5733-47B5-860C-23D7E62660E7"))));
        }

    }
}