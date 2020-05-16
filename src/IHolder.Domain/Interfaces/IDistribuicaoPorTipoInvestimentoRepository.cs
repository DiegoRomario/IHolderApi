using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IHolder.Domain.Interfaces
{
    public interface IDistribuicaoPorTipoInvestimentoRepository : IRepositoryBase<DistribuicaoPorTipoInvestimento>
    {
        Task<IEnumerable<DistribuicaoPorTipoInvestimento>> ObterDistribuicaoPorTipoInvestimento(params Expression<Func<DistribuicaoPorTipoInvestimento, object>>[] expression);
    }
}
