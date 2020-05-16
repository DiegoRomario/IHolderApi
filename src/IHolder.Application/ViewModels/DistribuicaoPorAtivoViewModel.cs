using System;

public class DistribuicaoPorAtivoViewModel
{
    public Guid Id { get; set; }
    public Guid AtivoId { get; set; }
    public string DescricaoAtivo { get; set; }
    public string CaracteristicasAtivo { get; set; }
    public decimal PercentualObjetivo { get; set; }
    public decimal PercentualAtual { get; set; }
    public decimal PercentualDiferenca { get; set; }
    public decimal ValorAtual { get; set; }
    public decimal ValorDiferenca { get; set; }
    public Guid UsuarioId { get; set; }
    public string Orientacao { get; private set; }
}