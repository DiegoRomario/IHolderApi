using IHolder.Domain.Enumerators;
using System;
namespace IHolder.Application.ViewModels
{
    public class DistribuicaoPorTipoInvestimentoViewModel
    {
        public Guid Id { get; set; }
        public Guid TipoInvestimentoId { get; set; }
        public string DescricaoTipoInvestimento { get; set; }
        public string CaracteristicasTipoInvestimento { get; set; }
        public decimal PercentualObjetivo { get; set; }
        public decimal PercentualAtual { get; set; }
        public decimal PercentualDiferenca { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal ValorDiferenca { get; set; }
        public Guid UsuarioId { get; set; }
        public string Orientacao { get; private set; }
    }
}
