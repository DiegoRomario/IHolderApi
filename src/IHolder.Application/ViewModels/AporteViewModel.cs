using System;

namespace IHolder.Application.ViewModels
{
    public class AporteViewModel
    {
        public Guid Id { get; set; }
        public Guid AtivoId { get; set; }
        public string AtivoTicker { get; set; }
        public string AtivoDescricao { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal PrecoMedio { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoTotal { get; private set; }
        public DateTime DataAporte { get; private set; }

    }
}
