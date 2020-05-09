﻿using IHolder.Domain.Entities;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Services
{
    public class AporteService : ServiceBase, IAporteService
    {
        private readonly IAporteRepository _aporteRepository;
        public AporteService(INotifier notifier) : base(notifier)
        {
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aporte>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Aporte entity)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> ObterTotalAplicado(Guid usuarioId)
        {
            return _aporteRepository.ObterTotalAplicado(usuarioId);
        }

        public Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipo_investimento_id, Guid usuarioId)
        {
            return _aporteRepository.ObterTotalAplicadoPorTipoInvestimento(tipo_investimento_id, usuarioId);
        }

        public Task<bool> Update(Aporte entity)
        {
            throw new NotImplementedException();
        }
    }
}
