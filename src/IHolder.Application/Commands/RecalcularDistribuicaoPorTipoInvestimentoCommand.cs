using IHolder.Application.Base;
using MediatR;
using System;

namespace IHolder.Application.Commands
{
    public class RecalcularDistribuicaoPorTipoInvestimentoCommand : Command<bool>
    {
        public RecalcularDistribuicaoPorTipoInvestimentoCommand(Guid usuarioId)
        {
            this.UsuarioId = usuarioId;
        }
        public Guid UsuarioId { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
