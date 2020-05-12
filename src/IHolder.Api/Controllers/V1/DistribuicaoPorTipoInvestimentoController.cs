using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IHolder.Api.Controllers.Base;
using IHolder.Api.ViewModels;
using IHolder.Domain.Entities;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using IHolder.Business.Commands;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DistribuicaoPorTipoInvestimentoController : ResponseBaseController
    {
        private readonly IMediator _mediator;

        public DistribuicaoPorTipoInvestimentoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult> Insert([FromBody]CadastrarDistribuicaoPorTipoInvestimentoCommand command)
        { 
            return ResponseBase(await _mediator.Send(command));
        }

        //[HttpPut("{id:guid}")]
        //public async Task<ActionResult> Insert(Guid id, DistribuicaoPorTipoInvestimentoViewModel model)
        //{
        //    //if (!ModelState.IsValid)
        //    //    return ResponseBase(ModelState);
        //    //if (id != model.Id)
        //    //{
        //    //    NotifyError("O ID do registro informado para alteração está inválido.");
        //    //    return ResponseBase();
        //    //}
        //    //await _distribuicaoPorTipoInvestimentoService.Update(_mapper.Map<DistribuicaoPorTipoInvestimento>(model));
        //    return ResponseBase();

        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DistribuicaoPorTipoInvestimentoViewModel>>> GetManyBy()
        //{
        //    //IEnumerable<DistribuicaoPorTipoInvestimento> response = await _distribuicaoPorTipoInvestimentoService.GetManyBy(d => d.UsuarioId == _user.GetUserId());
        //    return ResponseBase();
        //}

        //[HttpPost("recalcular")]
        //public async Task<ActionResult> Recalcular(DistribuicaoPorTipoInvestimentoViewModel model)
        //{
        //    //if (!ModelState.IsValid)
        //    //    return ResponseBase(ModelState);
        //    //await _distribuicaoPorTipoInvestimentoService.Recalcular(_mapper.Map<DistribuicaoPorTipoInvestimento>(model));
        //    return ResponseBase();

        //}

    }
}