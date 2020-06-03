using AutoMapper;
using IHolder.Data.Services.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Data.Services
{
    public class ConsultaCotacaoService : IConsultaCotacaoService
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;
        private const string APIKEY = "90JZCLU0FEQDLJZD";

        public ConsultaCotacaoService(HttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<Cotacao> ConsultarCotacao(ConsultaCotacaoArgs args, CancellationToken cancellationToken)
        {
            try
            {
                string URL = MontarURLDeConsultaPorTickerEProduto(args);
                HttpResponseMessage response = await _client.GetAsync(URL, cancellationToken);
                string result = string.Empty;
                result = await response.Content.ReadAsStringAsync();
                CotacaoContract cotacaoContract = JsonConvert.DeserializeObject<CotacaoRoot>(result.Replace("%", "")).Cotacao;
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

        public string MontarURLDeConsultaPorTickerEProduto(ConsultaCotacaoArgs args)
        {
            string symbol;

            switch (args.ProdutoDescricao.ToUpper())
            {
                case "FII":
                case "AÇÃO": symbol = $"{args.Ticker}.SA"; break;
                default: symbol = args.Ticker; break;
            }

            return $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={APIKEY}";
        }
    }
}
