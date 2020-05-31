using IHolder.Application.Queries;
using IHolder.Application.Services.Models;
using IHolder.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IAtivoQueries
    {
        Task<IEnumerable<AtivoViewModel>> ObterAtivosPorUsuario(Guid usuarioId);
        Task<Cotacao> ObterCotacaoPorTicker(AtivoConsultaCotacaoArgs args);
    }
}
