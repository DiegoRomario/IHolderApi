using Newtonsoft.Json;
using System;

namespace IHolder.Data.Services.Models
{
    public class Cotacao
    {
        public Cotacao()
        {

        }
        public Cotacao(decimal precoAnterior, decimal preco)
        {
            PrecoAnterior = precoAnterior;
            Preco = preco;
            CalcularVariacao();
        }

        public void CalcularVariacao ()
        {
            //Variacao = Preco - PrecoAnterior;
            //VariacaoPercentual = PrecoAnterior / Variacao * 100;
        }

        public decimal PrecoAnterior { get; private set; }
        public decimal Preco { get; private set; }
        public decimal Variacao { get; private set; }
        public decimal VariacaoPercentual { get; private set; }

    }

    //public class CotacaoContract
    //{
    //    [JsonProperty("01. symbol")]
    //    public string Ticker { get; set; }
    //    [JsonProperty("02. open")]
    //    public decimal Abertura { get; set; }
    //    [JsonProperty("03. high")]
    //    public decimal Maxima { get; set; }
    //    [JsonProperty("04. low")]
    //    public decimal Minima { get; set; }
    //    [JsonProperty("05. price")]
    //    public decimal Preco { get; set; }
    //    [JsonProperty("06. volume")]
    //    public decimal Volume { get; set; }
    //    [JsonProperty("07. latest trading day")]
    //    public string UltimoDataNegociacao { get; set; }
    //    [JsonProperty("08. previous close")]
    //    public decimal FechamentoAnterior { get; set; }
    //    [JsonProperty("09. change")]
    //    public decimal Variacao { get; set; }
    //    [JsonProperty("10. change percent")]
    //    public decimal VariacaoPercentual { get; set; }

    //}

    //public class CotacaoRoot
    //{
    //    [JsonProperty("Global Quote")]
    //    public CotacaoContract Cotacao { get; set; }
    //}

    public class ConsultaCotacaoArgs
    {
        public ConsultaCotacaoArgs()
        {

        }
        public ConsultaCotacaoArgs(string ticker, string produtoDescricao)
        {
            Ticker = ticker;
            ProdutoDescricao = produtoDescricao;
        }

        public string Ticker { get; set; }
        public string ProdutoDescricao { get; set; }
    }

    public partial class CotacaoRoot
    {
        [JsonProperty("chart")]
        public Chart Chart { get; set; }
    }

    public partial class Chart
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("timestamp")]
        public long[] Timestamp { get; set; }

        [JsonProperty("indicators")]
        public Indicators Indicators { get; set; }
    }

    public partial class Indicators
    {
        [JsonProperty("quote")]
        public Quote[] Quote { get; set; }

        [JsonProperty("adjclose")]
        public Adjclose[] Adjclose { get; set; }
    }

    public partial class Adjclose
    {
        [JsonProperty("adjclose")]
        public Decimal[] AdjcloseAdjclose { get; set; }
    }

    public partial class Quote
    {
        [JsonProperty("high")]
        public Decimal[] High { get; set; }

        [JsonProperty("low")]
        public Decimal[] Low { get; set; }

        [JsonProperty("volume")]
        public long[] Volume { get; set; }

        [JsonProperty("close")]
        public Decimal[] Close { get; set; }

        [JsonProperty("open")]
        public Decimal[] Open { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("instrumentType")]
        public string InstrumentType { get; set; }

        [JsonProperty("firstTradeDate")]
        public long FirstTradeDate { get; set; }

        [JsonProperty("regularMarketTime")]
        public long RegularMarketTime { get; set; }

        [JsonProperty("gmtoffset")]
        public long Gmtoffset { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonProperty("regularMarketPrice")]
        public Decimal RegularMarketPrice { get; set; }

        [JsonProperty("chartPreviousClose")]
        public Decimal ChartPreviousClose { get; set; }

        [JsonProperty("priceHint")]
        public long PriceHint { get; set; }

        [JsonProperty("currentTradingPeriod")]
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }

        [JsonProperty("dataGranularity")]
        public string DataGranularity { get; set; }

        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("validRanges")]
        public string[] ValidRanges { get; set; }
    }

    public partial class CurrentTradingPeriod
    {
        [JsonProperty("pre")]
        public Post Pre { get; set; }

        [JsonProperty("regular")]
        public Post Regular { get; set; }

        [JsonProperty("post")]
        public Post Post { get; set; }
    }

    public partial class Post
    {
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("gmtoffset")]
        public long Gmtoffset { get; set; }
    }
}
