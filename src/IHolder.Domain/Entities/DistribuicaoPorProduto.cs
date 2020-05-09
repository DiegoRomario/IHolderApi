using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorProduto : Entity
    {
        public DistribuicaoPorProduto(Guid distribuicaoPorTipoInvestimentoId, Guid produtoId, Guid usuarioId, Valores valores)
        {
            DistribuicaoPorTipoInvestimentoId = distribuicaoPorTipoInvestimentoId;
            ProdutoId = produtoId;
            Orientacao = EOrientacao.Manter;
            UsuarioId = usuarioId;
            Valores = valores;
        }
        public Valores Valores { get; set; }
        public Guid DistribuicaoPorTipoInvestimentoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public Guid UsuarioId { get; private set; }
        public DateTime IncluidoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        public DistribuicaoPorTipoInvestimento DistribuicaoPorTipoInvestimento { get; private set; }
        public Produto Produto { get; private set; }
        public Usuario Usuario { get; private set; }
        //public void AtualizarOrientacao(decimal percentual_diferenca)
        //{
        //    if (percentual_diferenca <= 0)
        //        Orientacao = EOrientacao.Manter;
        //    else
        //        Orientacao = EOrientacao.Comprar;

        //}

    }
}
