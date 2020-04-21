﻿using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities
{
    public class Distribuicao_por_ativo : Valores_base
    {

        public Distribuicao_por_ativo(Guid ativo_id, Guid usuario_id, decimal percentual_objetivo) : base(percentual_objetivo)
        {
            Ativo_id = ativo_id;
            Usuario_id = usuario_id;
        }

        public Guid Ativo_id { get; set; }
        public Guid Usuario_id { get; set; }
        public EOrientacao Orientacao { get; set; }
        public DateTime Data_inclusao { get; set; }
        public DateTime? Data_alteracao { get; set; }

        public Ativo Ativo { get; set; }
        public Usuario Usuario { get; set; }

        public void AtualizarOrientacao ()
        {
            AtualizarPercentualDiferenca();
            if (Percentual_diferenca <= 0)
                Orientacao = EOrientacao.Manter;
            else
                Orientacao = EOrientacao.Comprar;

        }

    }
}
