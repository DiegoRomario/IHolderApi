using IHolder.Domain.Entities;
using IHolder.Domain.Entities.Validations;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Repositories.Base;
using IHolder.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Services
{
    public class Tipo_investimentoService : ServiceBase, ITipoInvestimentoService
    {
        private readonly ITipoInvestimentoRepository _tipo_investimentoRepository;
        private readonly TipoInvestimentoValidation tipo_investimentoValidation;
        public Tipo_investimentoService(INotifier notifier, ITipoInvestimentoRepository tipo_investimentoRepository) : base(notifier)
        {
            _tipo_investimentoRepository = tipo_investimentoRepository;
            tipo_investimentoValidation = new TipoInvestimentoValidation(_tipo_investimentoRepository);
        }

        public async Task<IEnumerable<TipoInvestimento>> GetAll()
        {
            return await _tipo_investimentoRepository.GetAll();
        }

        public async Task<bool> Insert(TipoInvestimento entity)
        {

            if (!RunValidation(tipo_investimentoValidation, entity))
                return false;

            return await _tipo_investimentoRepository.Insert(entity);

        }

        public async Task<bool> Update(TipoInvestimento entity)
        {
            if (!RunValidation(tipo_investimentoValidation, entity))
                return false;

            return await _tipo_investimentoRepository.Update(entity);
        }
    }
}
