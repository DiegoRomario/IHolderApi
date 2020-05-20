using System;

public class DistribuicaoViewModel
{
    public Guid Id { get; set; }
    public Guid TipoDistribuicaoId { get; set; }
    public string Descricao { get; set; }
    public string Caracteristicas { get; set; }
    public decimal PercentualObjetivo { get; set; }
    public decimal PercentualAtual { get; set; }
    public decimal PercentualDiferenca { get; set; }
    public decimal ValorAtual { get; set; }
    public decimal ValorDiferenca { get; set; }
    public Guid UsuarioId { get; set; }
    public string Orientacao { get; private set; }
}