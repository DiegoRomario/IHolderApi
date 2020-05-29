using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IHolder.Api.Controllers.Base;
using IHolder.Application.Base;
using IHolder.Application.Queries;
using IHolder.Domain.DomainObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpGet()]
        [AllowAnonymous]
        public async Task<ActionResult> ObterAportes()
        {
            return ResponseBase(await _aporteQueries.ObterAportesPorUsuario(_user.GetUserId()));
        }
    
    }
}
