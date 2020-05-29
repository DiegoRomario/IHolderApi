using IHolder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IAporteQueries
    {
        Task<IEnumerable<AporteViewModel>> ObterAportesPorUsuario(Guid UsuarioId);
    }
}
