using IHolder.Domain.Entities;
using IHolder.Domain.Entities.Validations;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using IHolder.Domain.DomainObjects;

namespace IHolder.Business.Services
{
    public class TipoInvestimentoService : ServiceBase, ITipoInvestimentoService
    {
        private readonly IRepositoryBase<TipoInvestimento> _tipoInvestimentoRepository;
        private readonly TipoInvestimentoValidation tipoInvestimentoValidation;
        public TipoInvestimentoService(INotifier notifier, IRepositoryBase<TipoInvestimento> tipoInvestimentoRepository) : base(notifier)
        {
            _tipoInvestimentoRepository = tipoInvestimentoRepository;
            tipoInvestimentoValidation = new TipoInvestimentoValidation(_tipoInvestimentoRepository);
            _tipoInvestimentoRepository = tipoInvestimentoRepository;
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
