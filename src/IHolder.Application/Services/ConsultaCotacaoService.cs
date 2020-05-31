using AutoMapper;
using IHolder.Application.Queries;
using IHolder.Application.Services.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Services
{
    public class ConsultaCotacaoService : IConsultaCotacaoService
    {
        private readonly HttpClient _client;
        private string _apiURL;
        private readonly IMapper _mapper;

        public ConsultaCotacaoService(HttpClient client, IMapper mapper)
        {
            _client = client;
            _apiURL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=petr4.sa&apikey=90JZCLU0FEQDLJZD";
            _mapper = mapper;
        }

        public async Task<Cotacao> ConsultarCotacao(AtivoConsultaCotacaoArgs args, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_apiURL, cancellationToken);
                string result = string.Empty;
                result = await response.Content.ReadAsStringAsync();
                CotacaoContract cotacaoContract = JsonConvert.DeserializeObject<CotacaoRoot>(result.Replace ("%","")).Cotacao;
                if (response.IsSuccessStatusCode && cotacaoContract != null)
                    return _mapper.Map<Cotacao>(cotacaoContract);

                return new Cotacao();
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
