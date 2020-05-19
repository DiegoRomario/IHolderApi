using System;

public class DistribuicaoPorProdutoViewModel
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public string DescricaoProduto { get; set; }
    public string CaracteristicasProduto { get; set; }
    public decimal PercentualObjetivo { get; set; }
    public decimal PercentualAtual { get; set; }
    public decimal PercentualDiferenca { get; set; }
    public decimal ValorAtual { get; set; }
    public decimal ValorDiferenca { get; set; }
    public Guid UsuarioId { get; set; }
    public string Orientacao { get; private set; }
}