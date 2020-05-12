using System;

namespace IHolder.Api.ViewModels.Base
{
    public class Valores_baseViewModel 
    {
        public Guid Id { get; set; }
        public decimal PercentualObjetivo { get; set; }
        public decimal PercentualAtual { get; set; }
        public decimal PercentualDiferenca { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal ValorDiferenca { get; set; }
    }
}
