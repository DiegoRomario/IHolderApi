using IHolder.Domain.Entities;
using IHolder.Business.Interfaces.Services.Base;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services
{
    public interface IDistribuicaoPorTipoInvestimentoService : IServiceInsert<DistribuicaoPorTipoInvestimento>,
                                                                  IServiceUpdate<DistribuicaoPorTipoInvestimento>,
                                                                  IServiceGetManyBy<DistribuicaoPorTipoInvestimento>,
                                                                  IServiceDelete
    {
        Task<bool> Recalcular(DistribuicaoPorTipoInvestimento entity);
    }
}
