using IHolder.Domain.Entities;
using IHolder.Application.Interfaces.Services.Base;

namespace IHolder.Application.Interfaces.Services
{
    public interface IAtivoService : IServiceInsert<Ativo>, 
                                     IServiceUpdate<Ativo>,
                                     IServiceDelete, 
                                     IServiceGetAll<Ativo>
    {
    }
}
