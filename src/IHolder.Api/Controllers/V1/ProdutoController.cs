using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using IHolder.Application.Base;
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
    public class ProdutoController : ResponseBaseController
    {
        private readonly IProdutoQueries _queries;
        private readonly IUser _user;
        public ProdutoController(IMediator mediator, INotificationHandler<Notification> notification, IProdutoQueries queries, IUser user)
            : base(mediator, notification)
        {
            _queries = queries;
            _user = user;
        }


        [HttpGet()]
        public async Task<ActionResult> ObterProdutos()
        {
            return ResponseBase(await _queries.ObterProdutos());
        }

    }
}