using IHolder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IAtivoQueries
    {
        Task<IEnumerable<AtivoViewModel>> ObterAtivosPorUsuario(Guid usuarioId);
    }
}
