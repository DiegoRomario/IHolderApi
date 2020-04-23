using IHolder.Business.Entities;
using IHolder.Business.Entities.Validations;
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
    public class Tipo_investimentoService : ServiceBase, ITipo_investimentoService
    {
        private readonly ITipo_investimentoRepository _tipo_investimentoRepository;
        private readonly Tipo_investimentoValidation tipo_investimentoValidation;
        public Tipo_investimentoService(INotifier notifier, ITipo_investimentoRepository tipo_investimentoRepository) : base(notifier)
        {
            _tipo_investimentoRepository = tipo_investimentoRepository;
            tipo_investimentoValidation = new Tipo_investimentoValidation(_tipo_investimentoRepository);
        }

        public async Task<IEnumerable<Tipo_investimento>> GetAll()
        {
            return await _tipo_investimentoRepository.GetAll();
        }

        public async Task<bool> Insert(Tipo_investimento entity)
        {

            if (!RunValidation(tipo_investimentoValidation, entity))
                return false;

            return await _tipo_investimentoRepository.Insert(entity);

        }

        public async Task<bool> Update(Tipo_investimento entity)
        {
            if (!RunValidation(tipo_investimentoValidation, entity))
                return false;

            return await _tipo_investimentoRepository.Update(entity);
        }
    }
}
