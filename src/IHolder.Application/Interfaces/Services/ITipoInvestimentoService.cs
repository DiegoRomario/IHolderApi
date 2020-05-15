using IHolder.Application.Interfaces.Services.Base;
using IHolder.Domain.Entities;

namespace IHolder.Application.Interfaces.Services
{
    public interface ITipoInvestimentoService : IServiceInsert<TipoInvestimento>,
                                                 IServiceUpdate<TipoInvestimento>,
                                                 IServiceGetAll<TipoInvestimento>

    {

    }
}
