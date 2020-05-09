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
    public class Tipo_investimentoController : ResponseBaseController
    {
        private readonly ITipoInvestimentoService _tipo_InvestimentoService;
        public Tipo_investimentoController(INotifier notifier,
            IMapper mapper,
            ITipoInvestimentoService tipo_InvestimentoService, IUser user)
            : base(notifier, mapper, user)
        {
            _tipo_InvestimentoService = tipo_InvestimentoService;
        }

        [HttpPost()]
        public async Task<ActionResult> Insert(Tipo_investimentoViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(ModelState);
            await _tipo_InvestimentoService.Insert(_mapper.Map<TipoInvestimento>(model));
            return ResponseBase(model);
        }

        [HttpPut("{id:guid}")]
        public async Task <ActionResult> Update(Guid id, Tipo_investimentoViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(ModelState);
            if (id != model.Id)
            {
                NotifyError("O ID do registro informado para alteração está inválido.");
                return ResponseBase(null);
            }
            await _tipo_InvestimentoService.Update(_mapper.Map<TipoInvestimento>(model));
            return ResponseBase(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tipo_investimentoViewModel>>> GetAll()
        {
            IEnumerable<TipoInvestimento> response = await _tipo_InvestimentoService.GetAll();
            return ResponseBase(response);
        }

    }
}