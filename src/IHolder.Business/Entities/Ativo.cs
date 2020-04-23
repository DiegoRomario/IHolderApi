using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Ativo : Informacoes_base
    {

        public Ativo(Guid produto_id, string ticker, decimal cotacao, ERisco risco, Guid usuario_inclusao_id, string descricao, string caracteristicas) : base(descricao, caracteristicas)
        {
            Produto_id = produto_id;
            Ticker = ticker;
            Cotacao = cotacao;
            Risco = risco;
            Usuario_inclusao_id = usuario_inclusao_id;
        }

        public Guid Produto_id { get; private set; }
        public string Ticker { get; private set; }
        public decimal Cotacao { get; private set; }
        public Guid Usuario_inclusao_id { get; private set; }
        public DateTime Data_inclusao { get; private set; }
        public ERisco Risco { get; private set; }
        public Produto Produto { get; private set; }
        public Usuario Usuario_inclusao { get; private set; }


        public IEnumerable<Distribuicao_por_ativo> Distribuicoes_por_ativos { get; private set; }
        public IEnumerable<Aporte> Aportes { get; private set; }
        public IEnumerable<Situacao_por_ativo> Situacoes_por_ativos { get; private set; }

        public void AtualizarCotacao(decimal cotacao)
        {
            Cotacao = cotacao;
        }

    }
}
