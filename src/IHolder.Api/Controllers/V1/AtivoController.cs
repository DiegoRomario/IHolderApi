using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IHolder.Api.Controllers.Base;
using IHolder.Api.ViewModels;
using IHolder.Domain.Entities;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AtivoController : ResponseBaseController
    {
        private readonly IAtivoService _ativoService;

        public AtivoController(IAtivoService ativoService, IMapper mapper, INotifier notifier, IUser user) 
                                : base(notifier, mapper, user)
        {
            this._ativoService = ativoService;
        }
        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var response = _mapper.Map<IEnumerable<AtivoViewModel>>(await _ativoService.GetAll());
            return ResponseBase(response);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(AtivoViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(ModelState);

            var response = await _ativoService.Insert(_mapper.Map<Ativo>(model));
            return ResponseBase(response);
        }

    }
}