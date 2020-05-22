﻿using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IHolder.Domain.Entities
{
    public class Ativo : Entity
    {
        private Ativo()
        {
        }
        public Ativo(Guid produtoid, Informacoes informacoes, string ticker, decimal cotacao, Guid usuarioId) 
        {
            ProdutoId = produtoid;
            Ticker = ticker;
            Cotacao = cotacao;
            UsuarioId = usuarioId;
            Informacoes = informacoes;
            Situacao = ESituacao.Normal;
        }

        public Guid ProdutoId { get; private set; }
        public Informacoes Informacoes { get; set; }
        public string Ticker { get; private set; }
        public decimal Cotacao { get; private set; }
        public Guid UsuarioId { get; set; }
        public ESituacao Situacao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public Produto Produto { get; private set; }
        public Usuario Usuario { get; private set; }


        public IEnumerable<DistribuicaoPorAtivo> DistribuicoesPorAtivos { get; private set; }
        public IEnumerable<Aporte> Aportes { get; private set; }
        public void AtualizarCotacao(decimal cotacao)
        {
            Cotacao = cotacao;
        }

        public void AtualizarSitucao(ESituacao situacao)
        {
            Situacao = situacao;
        }

    }
}
