using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Distribuicao_por_ativo : Valores_base
    {

        public Distribuicao_por_ativo(Guid ativo_id, Guid usuario_id, decimal percentual_objetivo, decimal valor_atual) : base(percentual_objetivo, valor_atual)
        {
            Ativo_id = ativo_id;
            Usuario_id = usuario_id;
            Orientacao = EOrientacao.Manter;
        }

        public Guid Ativo_id { get; set; }
        public Guid Usuario_id { get; set; }
        public EOrientacao Orientacao { get; set; }
        public DateTime Data_inclusao { get; set; }
        public DateTime? Data_alteracao { get; set; }

        public Ativo Ativo { get; set; }
        public Usuario Usuario { get; set; }

        //public void AtualizarOrientacao (decimal percentual_diferenca)   
        //{
        //    if (percentual_diferenca <= 0)
        //        Orientacao = EOrientacao.Manter;
        //    else
        //        Orientacao = EOrientacao.Comprar;

        //}

    }
}
