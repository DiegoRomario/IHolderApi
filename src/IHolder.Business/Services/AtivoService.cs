using IHolder.Domain.Entities;
using IHolder.Domain.Entities.Validations;
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

        public async Task Delete(Guid id)
        {
            if (_aporteRepository.GetManyBy(a => a.AtivoId == id).Result.Any())
                Notify(new Notification("Este ativo não pode ser removido, pois encontra-se em lançamentos de distribuições e/ou aportes"));
            await _ativoRepository.Delete(id);
        }

        public async Task<IEnumerable<Ativo>> GetAll()
        {
            return await _ativoRepository.GetAll();
        }

        public async Task<bool> Insert(Ativo ativo)
        {
            if (!RunValidation(new AtivoValidation(), ativo))
                return false;

            return await _ativoRepository.Insert(ativo);

        }

        public Task<bool> Update(Ativo ativo)
        {
            throw new NotImplementedException();
        }
    }
}
