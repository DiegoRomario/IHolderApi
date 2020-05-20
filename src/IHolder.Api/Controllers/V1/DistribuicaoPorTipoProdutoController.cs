using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IHolder.Application.Base;
using System.Collections.Generic;
using IHolder.Domain.DomainObjects;
using IHolder.Application.Queries;
using IHolder.Application.Commands;
using System;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistribuicaoPorProdutoController : ResponseBaseController
    {
        private readonly IUser _user;
        private readonly IDistribuicaoPorProdutoQueries _distribuicaoPorProdutoQueries;

        public DistribuicaoPorProdutoController(IMediator mediator,
            IDistribuicaoPorProdutoQueries distribuicaoPorProdutoQueries,
            INotificationHandler<Notification> notificationHandler, IUser user) : base(mediator, notificationHandler)
        {
            _distribuicaoPorProdutoQueries = distribuicaoPorProdutoQueries;
            _user = user;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult> Cadastrar([FromBody] CadastrarDistribuicaoPorProdutoCommand command)
        {
            await _mediator.Send(command);
            return ResponseBase("Distribuição cadastrada com sucesso");
        }

        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult> Alterar(Guid id, AlterarDistribuicaoPorProdutoCommand command)
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
        public async Task<ActionResult> ObterDistribuicoesPorProduto()
        {
            IEnumerable<DistribuicaoViewModel> distribuicoes
                = await _distribuicaoPorProdutoQueries.ObterDistribuicaoPorProduto();
            return ResponseBase(distribuicoes);
        }

        [HttpPost("recalcular")]
        public async Task<ActionResult> Recalcular()
        {
            return ResponseBase(await _mediator.Send(new RecalcularDistribuicaoPorProdutoCommand(_user.GetUserId())));
        }

    }
}