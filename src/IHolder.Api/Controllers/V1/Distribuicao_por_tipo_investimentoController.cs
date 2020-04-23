using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IHolder.Api.Controllers.Base;
using IHolder.Api.ViewModels;
using IHolder.Business.Entities;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IHolder.Api.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class Distribuicao_por_tipo_investimentoController : ResponseBaseController
    {
        private IDistribuicao_por_tipo_investimentoService _distribuicao_Por_Tipo_InvestimentoService;
        public Distribuicao_por_tipo_investimentoController(INotifier notifier,
                                                            IMapper mapper,
                                                            IUser user,
                                                            IDistribuicao_por_tipo_investimentoService distribuicao_Por_Tipo_InvestimentoService) : base(notifier, mapper, user)
        {
            _distribuicao_Por_Tipo_InvestimentoService = distribuicao_Por_Tipo_InvestimentoService;
        }

        [HttpPost()]
        public async Task<ActionResult> Insert(Distribuicao_por_tipo_investimentoViewModel model)
        {
            if (!ModelState.IsValid)
                return ResponseBase(model);
            await _distribuicao_Por_Tipo_InvestimentoService.Insert(_mapper.Map<Distribuicao_por_tipo_investimento>(model));
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
            await _distribuicao_Por_Tipo_InvestimentoService.Update(_mapper.Map<Distribuicao_por_tipo_investimento>(model));
            return ResponseBase(model);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distribuicao_por_tipo_investimentoViewModel>>> GetManyBy()
        {
            IEnumerable<Distribuicao_por_tipo_investimento> response = await _distribuicao_Por_Tipo_InvestimentoService.GetManyBy(d => d.Usuario_id == _user.GetUserId());
            return ResponseBase(response);
        }

    }
}