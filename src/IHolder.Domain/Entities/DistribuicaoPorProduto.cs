using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorProduto : Entity
    {
        private DistribuicaoPorProduto()
        {

        }
        public DistribuicaoPorProduto(Guid produtoId, Guid usuarioId, Valores valores)
        {
            ProdutoId = produtoId;
            Orientacao = EOrientacao.Hold;
            UsuarioId = usuarioId;
            Valores = valores;
        }
        public Valores Valores { get; set; }
        public Guid ProdutoId { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public Guid UsuarioId { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public Produto Produto { get; private set; }
        public Usuario Usuario { get; private set; }
        public void AtualizarOrientacao()
        {
            if (Valores.PercentualDiferenca <= 0)
                Orientacao = EOrientacao.Hold;
            else
                Orientacao = EOrientacao.Buy;
        }

    }
}
