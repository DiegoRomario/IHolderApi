using IHolder.Domain.DomainObjects;
using System;
using System.Threading.Tasks;
using IHolder.Domain.Entities;

namespace IHolder.Domain.Interfaces
{
    public interface IAtivoEmCarteiraRepository : IRepositoryBase<AtivoEmCarteira>
    {
        Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId);
        Task<decimal> ObterTotalAplicadoPorAtivo(Guid ativoId, Guid usuarioId);
        Task<decimal> ObterTotalAplicadoPorProduto(Guid produtoId, Guid usuarioId);
        Task<decimal> ObterTotalAplicado(Guid usuarioId);
    }
}
