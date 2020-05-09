using IHolder.Domain.Entities;
using IHolder.Business.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services
{
    public interface IAporteService : IServiceInsert<Aporte>,
                                     IServiceUpdate<Aporte>,
                                     IServiceGetAll<Aporte>,
                                     IServiceDelete
    {
        Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId);
        Task<decimal> ObterTotalAplicado(Guid usuarioId);
    }
}
