using  IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using System;

namespace IHolder.Domain.Entities
{
    public class SituacaoPorAtivo : Entity
    {
        public SituacaoPorAtivo(ESituacao situacao, Guid ativoId, Guid usuarioId, string observacao)
        {
            Situacao = situacao;
            AtivoId = ativoId;
            UsuarioId = usuarioId;
            Observacao = observacao;
        }

        public ESituacao Situacao { get; private set; }
        public Guid AtivoId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public string Observacao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
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
