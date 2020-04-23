using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Tipo_investimento : Informacoes_base
    {
        public Tipo_investimento(ERisco risco, string descricao, string caracteristicas) : base(descricao, caracteristicas)
        {
            Risco = risco;
        }
        public ERisco Risco { get; private set; }
        public IEnumerable<Distribuicao_por_tipo_investimento> Distribuicoes_por_tipos_investimentos { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }

        public void AlterarRisco(ERisco risco)
        {
            Risco = risco;
        }

    }
}
