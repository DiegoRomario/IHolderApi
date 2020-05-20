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
    public class AtivoController : ResponseBaseController
    {
        private readonly IAtivoQueries _queries;
        private readonly IUser _user;
        public AtivoController(IMediator mediator, INotificationHandler<Notification> notification, IAtivoQueries queries, IUser user)
            : base(mediator, notification)
        {
            _queries = queries;
            _user = user;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Insert(CadastrarAtivoCommand command)
        {
            await _mediator.Send(command);
            return ResponseBase("Ativo cadastrado com sucesso");
        }



        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult> Alterar(Guid id, AlterarAtivoCommand command)
        {
            if (id != command.Id)
            {
                NotifyError("O ID do registro informado para alteração está inválido.");
                return ResponseBase();
            }
            await _mediator.Send(command);
            return ResponseBase("Registro alterado com sucesso");
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<ActionResult> ObterAtivos()
        {
            return ResponseBase(await _queries.ObterAtivosPorUsuario(_user.GetUserId()));
        }

    }
}