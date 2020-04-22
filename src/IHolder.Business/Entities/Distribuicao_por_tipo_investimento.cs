﻿using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Distribuicao_por_tipo_investimento : Valores_base
    {
        public Distribuicao_por_tipo_investimento(Guid tipo_investimento_id, EOrientacao orientacao, Guid usuario_id, decimal percentual_objetivo, decimal valor_atual) : base(percentual_objetivo, valor_atual)
        {
            Tipo_investimento_id = tipo_investimento_id;
            Orientacao = orientacao;
            Usuario_id = usuario_id;
        }

        public Guid Tipo_investimento_id { get; set; }
        public EOrientacao Orientacao { get; set; }
        public Guid Usuario_id { get; set; }
        public DateTime Data_inclusao { get; set; }
        public DateTime? Data_alteracao { get; set; }

        // EF RELATIONS
        public Tipo_investimento Tipo_investimento { get; set; }

        public Usuario Usuario { get; set; }
        public IEnumerable<Distribuicao_por_produto> Distribuicoes_por_produtos { get; set; }

        //public void AtualizarOrientacao(decimal percentual_diferenca)
        //{
        //    if (percentual_diferenca <= 0)
        //        Orientacao = EOrientacao.Manter;
        //    else
        //        Orientacao = EOrientacao.Comprar;

        //}

    }
}
