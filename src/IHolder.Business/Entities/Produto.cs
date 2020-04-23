using IHolder.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Produto : Informacoes_base
    {
        public Produto(Guid tipo_investimento_id, string descricao, string caracteristicas) : base(descricao, caracteristicas)
        {
            Tipo_investimento_id = tipo_investimento_id;
        }

        public Guid Tipo_investimento_id { get; private set; }

        public Tipo_investimento Tipo_investimento { get; private set; }
        public IEnumerable<Distribuicao_por_produto> Distribuicoes_por_produtos { get; private set; }
        public IEnumerable<Ativo> Ativos { get; private set; }
    }
}
