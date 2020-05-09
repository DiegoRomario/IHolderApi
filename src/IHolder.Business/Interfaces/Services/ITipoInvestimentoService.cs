using IHolder.Business.Interfaces.Services.Base;
using IHolder.Domain.Entities;

namespace IHolder.Business.Interfaces.Services
{
    public interface ITipoInvestimentoService : IServiceInsert<TipoInvestimento>,
                                                 IServiceUpdate<TipoInvestimento>,
                                                 IServiceGetAll<TipoInvestimento>

    {

    }
}
