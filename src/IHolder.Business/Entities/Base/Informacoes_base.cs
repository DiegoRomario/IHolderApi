using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Entities.Base
{
    public abstract class Informacoes_base : Entidade_base
    {
        protected Informacoes_base(string descricao, string caracteristicas)
        {
            Descricao = descricao;
            Caracteristicas = caracteristicas;
        }

        public string Descricao { get; private set; }
        public string Caracteristicas { get; private set; }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void AlterarCaracteristicas(string caracteristicas)
        {
            Caracteristicas = caracteristicas;
        }
    }
}
