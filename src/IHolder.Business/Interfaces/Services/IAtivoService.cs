using IHolder.Domain.Entities;
using IHolder.Business.Interfaces.Services.Base;

namespace IHolder.Business.Interfaces.Services
{
    public interface IAtivoService : IServiceInsert<Ativo>, 
                                     IServiceUpdate<Ativo>,
                                     IServiceDelete, 
                                     IServiceGetAll<Ativo>
    {
    }
}
