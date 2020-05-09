using IHolder.Business.Repositories.Base;
using System;
using System.Threading.Tasks;
using IHolder.Domain.Entities;

namespace IHolder.Business.Interfaces.Repositories
{
    public interface IAporteRepository : IRepositoryBase<Aporte>
    {
        Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId);
        Task<decimal> ObterTotalAplicado(Guid usuarioId);
    }
}
