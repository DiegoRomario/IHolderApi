using IHolder.Domain.Entities;
using IHolder.Domain.Entities.Validations;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Business.Interfaces.Services;
using IHolder.Business.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Services
{
    public class Distribuicao_por_tipo_investimentoService : ServiceBase, IDistribuicaoPorTipoInvestimentoService
    {
        private readonly IDistribuicaoPorTipoInvestimentoRepository _distribuicao_Por_Tipo_InvestimentoRepository;
        private readonly IAporteRepository _aporteRepository;
        private readonly DistribuicaoPorTipoInvestimentoValidation _validation;
        public Distribuicao_por_tipo_investimentoService(INotifier notifier,
                                                         IDistribuicaoPorTipoInvestimentoRepository distribuicao_Por_Tipo_InvestimentoRepository, IAporteRepository aporteRepository) : base(notifier)
        {
            _distribuicao_Por_Tipo_InvestimentoRepository = distribuicao_Por_Tipo_InvestimentoRepository;
            _aporteRepository = aporteRepository;
            _validation = new DistribuicaoPorTipoInvestimentoValidation(_distribuicao_Por_Tipo_InvestimentoRepository);

        }

        public async Task Delete(Guid id)
        {
            #warning IMPLEMENTAR VALIDAÇÃO 
            await _distribuicao_Por_Tipo_InvestimentoRepository.Delete(id);

        }

        public async Task<IEnumerable<DistribuicaoPorTipoInvestimento>> GetManyBy(Expression<Func<DistribuicaoPorTipoInvestimento, bool>> predicate)
        {
           return await _distribuicao_Por_Tipo_InvestimentoRepository.GetManyBy(predicate);
        }

        public async Task<bool> Insert(DistribuicaoPorTipoInvestimento entity)
        {

            if (!RunValidation(_validation, entity))
                return false;
            return await _distribuicao_Por_Tipo_InvestimentoRepository.Insert(entity);
        }

        public Task<bool> Recalcular(DistribuicaoPorTipoInvestimento entity)
        {
            var valor_total_por_tipo_investimento = _aporteRepository.ObterTotalAplicadoPorTipoInvestimento(entity.TipoInvestimentoId, entity.UsuarioId).Result;
            var valor_total = _aporteRepository.ObterTotalAplicado(entity.UsuarioId).Result;
            entity.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valor_total_por_tipo_investimento, valor_total);
            entity.AtualizarOrientacao();
            return Update(entity);
        }

        public async Task<bool> Update(DistribuicaoPorTipoInvestimento entity)
        {
            if (!RunValidation(_validation, entity))
                return false;
            return await _distribuicao_Por_Tipo_InvestimentoRepository.Update(entity);
        }





    }
}
