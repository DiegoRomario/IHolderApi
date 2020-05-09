using IHolder.Domain.DomainObjects;
using System;
using System.Threading.Tasks;
using IHolder.Domain.Entities;

namespace IHolder.Domain.Interfaces
{
    public interface IAporteRepository : IRepositoryBase<Aporte>
    {
        Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId);
        Task<decimal> ObterTotalAplicado(Guid usuarioId);
    }
}
