using IHolder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IAtivoEmCarteiraQueries
    {
        Task<IEnumerable<AtivoEmCarteiraViewModel>> ObterAtivosEmCarteiraPorUsuario(Guid UsuarioId);
    }
}
