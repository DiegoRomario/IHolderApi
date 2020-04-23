using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Distribuicao_por_produto : Valores_base
    {
        public Distribuicao_por_produto(Guid distribuicao_por_tipo_investimento_id, Guid produto_id, Guid usuario_id, decimal percentual_objetivo, decimal valor_atual) :
            base(percentual_objetivo, valor_atual)
        {
            Distribuicao_por_tipo_investimento_id = distribuicao_por_tipo_investimento_id;
            Produto_id = produto_id;
            Orientacao = EOrientacao.Manter;
            Usuario_id = usuario_id;
        }
        public Guid Distribuicao_por_tipo_investimento_id { get; private set; }
        public Guid Produto_id { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public Guid Usuario_id { get; private set; }
        public DateTime Data_inclusao { get; private set; }
        public DateTime? Data_alteracao { get; private set; }

        public Distribuicao_por_tipo_investimento Distribuicao_por_tipo_investimento { get; private set; }
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
