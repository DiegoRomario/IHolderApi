using IHolder.Domain.Entities;
using IHolder.Domain.Entities.Validations;
using IHolder.Application.Interfaces.Notifications;

using IHolder.Application.Interfaces.Services;
using IHolder.Application.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IHolder.Domain.Interfaces;
using IHolder.Domain.DomainObjects;

namespace IHolder.Application.Services
{
    public class DistribuicaoPorTipoInvestimentoService : ServiceBase, IDistribuicaoPorTipoInvestimentoService
    {
        private readonly IRepositoryBase<DistribuicaoPorTipoInvestimento> _distribuicaoPorTipoInvestimentoRepository;
        private readonly IAporteRepository _aporteRepository;
        private readonly DistribuicaoPorTipoInvestimentoValidation _validation;
        public DistribuicaoPorTipoInvestimentoService(INotifier notifier,
                                                         IRepositoryBase<DistribuicaoPorTipoInvestimento> distribuicaoPorTipoInvestimentoRepository, IAporteRepository aporteRepository) : base(notifier)
        {
            _distribuicaoPorTipoInvestimentoRepository = distribuicaoPorTipoInvestimentoRepository;
            _aporteRepository = aporteRepository;
            _validation = new DistribuicaoPorTipoInvestimentoValidation(_distribuicaoPorTipoInvestimentoRepository);

        }

        public async Task Delete(Guid id)
        {
            #warning IMPLEMENTAR VALIDAÇÃO 
            await _distribuicaoPorTipoInvestimentoRepository.Delete(id);

        }

        public async Task<IEnumerable<DistribuicaoPorTipoInvestimento>> GetManyBy(Expression<Func<DistribuicaoPorTipoInvestimento, bool>> predicate)
        {
           return await _distribuicaoPorTipoInvestimentoRepository.GetManyBy(predicate);
        }

        public async Task<bool> Insert(DistribuicaoPorTipoInvestimento entity)
        {

            if (!RunValidation(_validation, entity))
                return false;
            return await _distribuicaoPorTipoInvestimentoRepository.Insert(entity);
        }

        public Task<bool> Recalcular(DistribuicaoPorTipoInvestimento entity)
        {
            var valorTotalPorTipoInvestimento = _aporteRepository.ObterTotalAplicadoPorTipoInvestimento(entity.TipoInvestimentoId, entity.UsuarioId).Result;
            var valor_total = _aporteRepository.ObterTotalAplicado(entity.UsuarioId).Result;
            entity.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorTipoInvestimento, valor_total);
            entity.AtualizarOrientacao();
            return Update(entity);
        }

        public async Task<bool> Update(DistribuicaoPorTipoInvestimento entity)
        {
            if (!RunValidation(_validation, entity))
                return false;
            return await _distribuicaoPorTipoInvestimentoRepository.Update(entity);
        }





    }
}
