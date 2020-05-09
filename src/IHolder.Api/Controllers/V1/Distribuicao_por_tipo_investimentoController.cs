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

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class Distribuicao_por_tipo_investimentoController : ResponseBaseController
    {
        private IDistribuicaoPorTipoInvestimentoService _distribuicao_Por_Tipo_InvestimentoService;
        public Distribuicao_por_tipo_investimentoController(INotifier notifier,
                                                            IMapper mapper,
                                                            IUser user,
                                                            IDistribuicaoPorTipoInvestimentoService distribuicao_Por_Tipo_InvestimentoService) : base(notifier, mapper, user)
        {
            _distribuicao_Por_Tipo_InvestimentoService = distribuicao_Por_Tipo_InvestimentoService;
        }

        [HttpPost()]
        public async Task<ActionResult> Insert(Distribuicao_por_tipo_investimentoViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(model);
            await _distribuicao_Por_Tipo_InvestimentoService.Insert(_mapper.Map<DistribuicaoPorTipoInvestimento>(model));
            return ResponseBase(model);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Insert(Guid id, Distribuicao_por_tipo_investimentoViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(ModelState);
            if (id != model.Id)
            {
                NotifyError("O ID do registro informado para alteração está inválido.");
                return ResponseBase(null);
            }
            await _distribuicao_Por_Tipo_InvestimentoService.Update(_mapper.Map<DistribuicaoPorTipoInvestimento>(model));
            return ResponseBase(model);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distribuicao_por_tipo_investimentoViewModel>>> GetManyBy()
        {
            IEnumerable<DistribuicaoPorTipoInvestimento> response = await _distribuicao_Por_Tipo_InvestimentoService.GetManyBy(d => d.UsuarioId == _user.GetUserId());
            return ResponseBase(response);
        }

        [HttpPost("recalcular")]
        public async Task<ActionResult> Recalcular(Distribuicao_por_tipo_investimentoViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(ModelState);
            await _distribuicao_Por_Tipo_InvestimentoService.Recalcular(_mapper.Map<DistribuicaoPorTipoInvestimento>(model));
            return ResponseBase(model);

        }

    }
}