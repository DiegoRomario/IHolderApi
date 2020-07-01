using IHolder.Domain.Enumerators;
using IHolder.Domain.Interfaces;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorProduto : IDistribuicao
    {
        private DistribuicaoPorProduto(){}
        public DistribuicaoPorProduto(Guid produtoId, Guid usuarioId, Valores valores) : base (valores)
        {
            ProdutoId = produtoId;
            Orientacao = EOrientacao.Hold;
            UsuarioId = usuarioId;
        }
        public Guid ProdutoId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Produto Produto { get; private set; }
        protected override EOrientacao SugerirOrientacao()
        {
            if (ExcedePercentualDeDiferenca())
                return EOrientacao.Sell;
            else if (Valores.PercentualDiferenca <= 0)
                return EOrientacao.Hold;
            else
                return EOrientacao.Buy;
        }
    }
}
