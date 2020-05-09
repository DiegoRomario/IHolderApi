using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IHolder.Domain.Entities
{
    public class Ativo : Entity
    {

        public Ativo(Guid produtoid, Informacoes informacoes, string ticker, decimal cotacao, ERisco risco, Guid usuarioId) 
        {
            ProdutoId = produtoid;
            Ticker = ticker;
            Cotacao = cotacao;
            Risco = risco;
            UsuarioId = usuarioId;
            Informacoes = informacoes;
        }

        public Guid ProdutoId { get; private set; }
        public Informacoes Informacoes { get; set; }
        public string Ticker { get; private set; }
        public decimal Cotacao { get; private set; }
        public Guid UsuarioId { get; set; }
        public DateTime IncluidoEm { get; private set; }
        public DateTime AlteradoEm { get; private set; }
        public ERisco Risco { get; private set; }
        public Produto Produto { get; private set; }
        public Usuario Usuario { get; private set; }


        public IEnumerable<DistribuicaoPorAtivo> DistribuicoesPorAtivos { get; private set; }
        public IEnumerable<Aporte> Aportes { get; private set; }
        public IEnumerable<SituacaoPorAtivo> SituacoesPorAtivos { get; private set; }

        public void AtualizarCotacao(decimal cotacao)
        {
            Cotacao = cotacao;
        }

    }
}
