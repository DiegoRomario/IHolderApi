using IHolder.Business.Entities;
using IHolder.Business.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Repositories
{
    public interface IAporteRepository : IRepositoryBase<Aporte>
    {
        Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipo_investimento_id, Guid usuario_id);
        Task<decimal> ObterTotalAplicado(Guid usuario_id);
    }
}
