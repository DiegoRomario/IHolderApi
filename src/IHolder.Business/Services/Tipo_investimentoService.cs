﻿using IHolder.Domain.Entities;
using IHolder.Domain.Entities.Validations;
using IHolder.Business.Interfaces.Notifications;

using IHolder.Business.Interfaces.Services;

using IHolder.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IHolder.Domain.Interfaces;

namespace IHolder.Business.Services
{
    public class TipoInvestimentoService : ServiceBase, ITipoInvestimentoService
    {
        private readonly ITipoInvestimentoRepository _tipoInvestimentoRepository;
        private readonly TipoInvestimentoValidation tipoInvestimentoValidation;
        public TipoInvestimentoService(INotifier notifier, ITipoInvestimentoRepository tipoInvestimentoRepository) : base(notifier)
        {
            _tipoInvestimentoRepository = tipoInvestimentoRepository;
            tipoInvestimentoValidation = new TipoInvestimentoValidation(_tipoInvestimentoRepository);
        }

        public async Task<IEnumerable<TipoInvestimento>> GetAll()
        {
            return await _tipoInvestimentoRepository.GetAll();
        }

        public async Task<bool> Insert(TipoInvestimento entity)
        {

            if (!RunValidation(tipoInvestimentoValidation, entity))
                return false;

            return await _tipoInvestimentoRepository.Insert(entity);

        }

        public async Task<bool> Update(TipoInvestimento entity)
        {
            if (!RunValidation(tipoInvestimentoValidation, entity))
                return false;

            return await _tipoInvestimentoRepository.Update(entity);
        }
    }
}
