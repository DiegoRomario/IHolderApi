using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorAtivo : Entity
    {
        private DistribuicaoPorAtivo()
        {
        }
        public DistribuicaoPorAtivo(Guid distribuicaoPorProdutoId, Guid ativoId, Guid usuarioId, Valores valores)
        {
            DistribuicaoPorProdutoId = distribuicaoPorProdutoId;
            AtivoId = ativoId;
            UsuarioId = usuarioId;
            Orientacao = EOrientacao.Hold;
            Valores = valores;
        }
        public Guid DistribuicaoPorProdutoId { get; private set; }
        public  Valores Valores { get; private set; }
        public Guid AtivoId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        public DistribuicaoPorProduto DistribuicaoPorProduto { get; private set; }
        public Ativo Ativo { get; private set; }
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
