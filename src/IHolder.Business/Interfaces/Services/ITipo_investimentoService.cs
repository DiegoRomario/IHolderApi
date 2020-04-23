using IHolder.Business.Entities;
using IHolder.Business.Interfaces.Services.Base;
namespace IHolder.Business.Interfaces.Services
{
    public interface ITipo_investimentoService : IServiceInsert<Tipo_investimento>,
                                                 IServiceUpdate<Tipo_investimento>,
                                                 IServiceGetAll<Tipo_investimento>

    {

    }
}
