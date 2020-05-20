using IHolder.Application.Base;
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


    }
}
