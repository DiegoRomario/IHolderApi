using IHolder.Domain.Entities;
using IHolder.Application.Interfaces.Services.Base;
using System.Threading.Tasks;

namespace IHolder.Application.Interfaces.Services
{
    public interface IDistribuicaoPorTipoInvestimentoService : IServiceInsert<DistribuicaoPorTipoInvestimento>,
                                                                  IServiceUpdate<DistribuicaoPorTipoInvestimento>,
                                                                  IServiceGetManyBy<DistribuicaoPorTipoInvestimento>,
                                                                  IServiceDelete
    {
        Task<bool> Recalcular(DistribuicaoPorTipoInvestimento entity);
    }
}
