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

        public ConsultaCotacaoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Cotacao> ConsultarCotacao(ConsultaCotacaoArgs args, CancellationToken cancellationToken)
        {
            try
            {
                string URL = MontarURLDeConsultaPorTickerEProduto(args);
                HttpResponseMessage response = await _client.GetAsync(URL, cancellationToken);
                string result = string.Empty;
                result = await response.Content.ReadAsStringAsync();
                Meta meta = JsonConvert.DeserializeObject<CotacaoRoot>(result).Chart.Result[0].Meta;
                if (response.IsSuccessStatusCode && meta != null)
                    return new Cotacao(meta.ChartPreviousClose, meta.RegularMarketPrice);

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

            return $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?interval=1d";
        }
    }
}
