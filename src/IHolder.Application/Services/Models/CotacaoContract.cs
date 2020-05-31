using Newtonsoft.Json;

namespace IHolder.Application.Services.Models
{
    public class Cotacao
    {
        public string Ticker { get; set; }
        public decimal Abertura { get; set; }
        public decimal Maxima { get; set; }
        public decimal Minima { get; set; }
        public decimal Preco { get; set; }
        public decimal Volume { get; set; }
        public string UltimoDataNegociacao { get; set; }
        public decimal FechamentoAnterior { get; set; }
        public decimal Variacao { get; set; }
        public decimal VariacaoPercentual { get; set; }

    }

    public class CotacaoContract
    {
        [JsonProperty("01. symbol")]
        public string Ticker { get; set; }
        [JsonProperty("02. open")]
        public decimal Abertura { get; set; }
        [JsonProperty("03. high")]
        public decimal Maxima { get; set; }
        [JsonProperty("04. low")]
        public decimal Minima { get; set; }
        [JsonProperty("05. price")]
        public decimal Preco { get; set; }
        [JsonProperty("06. volume")]
        public decimal Volume { get; set; }
        [JsonProperty("07. latest trading day")]
        public string UltimoDataNegociacao { get; set; }
        [JsonProperty("08. previous close")]
        public decimal FechamentoAnterior { get; set; }
        [JsonProperty("09. change")]
        public decimal Variacao { get; set; }
        [JsonProperty("10. change percent")]
        public decimal VariacaoPercentual { get; set; }

    }

    public class CotacaoRoot
    {
        [JsonProperty("Global Quote")]
        public CotacaoContract Cotacao { get; set; }
    }
}
