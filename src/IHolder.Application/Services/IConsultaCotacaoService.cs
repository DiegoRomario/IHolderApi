using IHolder.Application.Queries;
using IHolder.Application.Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Services
{
    public interface IConsultaCotacaoService
    {
        Task<Cotacao> ConsultarCotacao(AtivoConsultaCotacaoArgs args, CancellationToken cancellationToken);
    }
}