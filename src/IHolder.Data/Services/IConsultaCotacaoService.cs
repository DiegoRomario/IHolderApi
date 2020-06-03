using IHolder.Data.Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Data.Services
{
    public interface IConsultaCotacaoService
    {
        Task<Cotacao> ConsultarCotacao(ConsultaCotacaoArgs args, CancellationToken cancellationToken);
    }
}


