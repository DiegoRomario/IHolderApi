﻿using IHolder.Business.Entities;
using IHolder.Business.Entities.Validations;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Notifications;
using IHolder.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Services
{
    public class AtivoService : ServiceBase, IAtivoService
    {
        private readonly IAtivoRepository _ativoRepository;
        private readonly IAporteRepository _aporteRepository;

        public AtivoService(IAtivoRepository ativoRepository, IAporteRepository aporteRepository, INotifier notifier) : base(notifier)
        {
            _ativoRepository = ativoRepository;
            _aporteRepository = aporteRepository;
        }

        public async Task Delete(int id)
        {
            if (_aporteRepository.GetBy(a => a.Ativo_id == id).Result.Any())
                Notify(new Notification("Este ativo não pode ser removido, pois encontra-se em lançamentos de distribuições e/ou aportes"));
            await _ativoRepository.Delete(id);
        }

        public async Task<IEnumerable<Ativo>> GetAll()
        {
            return await _ativoRepository.GetAll();
        }

        public async Task<int> Insert(Ativo ativo)
        {
            if (!RunValidation(new AtivoValidation(), ativo))
                return 0;

            return await _ativoRepository.Insert(ativo);

        }

        public Task<int> Update(Ativo ativo)
        {
            throw new NotImplementedException();
        }
    }
}
