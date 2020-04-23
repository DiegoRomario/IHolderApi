using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Distribuicao_por_tipo_investimento : Valores_base
    {
        public Distribuicao_por_tipo_investimento(Guid tipo_investimento_id, Guid usuario_id, decimal percentual_objetivo, decimal valor_atual) : base(percentual_objetivo, valor_atual)
        {
            Tipo_investimento_id = tipo_investimento_id;
            Orientacao = EOrientacao.Manter;
            Usuario_id = usuario_id;
        }

        public Guid Tipo_investimento_id { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public Guid Usuario_id { get; private set; }
        public DateTime Data_inclusao { get; private set; }
        public DateTime? Data_alteracao { get; private set; }

        // EF RELATIONS
        public Tipo_investimento Tipo_investimento { get; private set; }

        public Usuario Usuario { get; private set; }
        public IEnumerable<Distribuicao_por_produto> Distribuicoes_por_produtos { get; private set; }

        //public void AtualizarOrientacao(decimal percentual_diferenca)
        //{
        //    if (percentual_diferenca <= 0)
        //        Orientacao = EOrientacao.Manter;
        //    else
        //        Orientacao = EOrientacao.Comprar;

        //}

    }
}
