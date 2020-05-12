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
    public class TipoInvestimentoController : ResponseBaseController
    {
        private readonly ITipoInvestimentoService _tipoInvestimentoService;
        public TipoInvestimentoController(INotifier notifier,
            IMapper mapper,
            ITipoInvestimentoService tipoInvestimentoService, IUser user)
        {
            _tipoInvestimentoService = tipoInvestimentoService;
        }

        //[HttpPost()]
        //public async Task<ActionResult> Insert(TipoInvestimentoViewModel model)
        //{
        //    //if (!ModelState.IsValid)
        //    //    return ResponseBase(ModelState);
        //    //await _tipoInvestimentoService.Insert(_mapper.Map<TipoInvestimento>(model));
        //    return ResponseBase();
        //}

        //[HttpPut("{id:guid}")]
        //public async Task <ActionResult> Update(Guid id, TipoInvestimentoViewModel model)
        //{
        //    //if (!ModelState.IsValid)
        //    //    return ResponseBase(ModelState);
        //    //if (id != model.Id)
        //    //{
        //    //    NotifyError("O ID do registro informado para alteração está inválido.");
        //    //    return ResponseBase();
        //    //}
        //    //await _tipoInvestimentoService.Update(_mapper.Map<TipoInvestimento>(model));
        //    return ResponseBase();
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<ActionResult<IEnumerable<TipoInvestimentoViewModel>>> GetAll()
        //{
        //    //IEnumerable<TipoInvestimento> response = await _tipoInvestimentoService.GetAll();
        //    return ResponseBase();
        //}

    }
}