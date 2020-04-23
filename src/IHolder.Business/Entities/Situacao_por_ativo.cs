using IHolder.Business.Entities.Base;
using IHolder.Business.Entities.Enumerators;
using System;

namespace IHolder.Business.Entities
{
    public class Situacao_por_ativo : Entidade_base
    {
        public Situacao_por_ativo(ESituacao situacao, Guid ativo_id, Guid usuario_id, string observacao)
        {
            Situacao = situacao;
            Ativo_id = ativo_id;
            Usuario_id = usuario_id;
            Observacao = observacao;
        }

        public ESituacao Situacao { get; private set; }
        public Guid Ativo_id { get; private set; }
        public Guid Usuario_id { get; private set; }
        public string Observacao { get; private set; }
        public DateTime Data_inclusao { get; private set; }
        public DateTime? Data_alteracao { get; private set; }
        public Ativo Ativo { get; private set; }
        public Usuario Usuario { get; private set; }

        public void AlterarSituacao(ESituacao situacao)
        {
            Situacao = situacao;
        }

        public void AlterarObservacao(string observacao)
        {
            Observacao = observacao;
        }
    }
}
