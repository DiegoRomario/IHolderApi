using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class RecalcularDistribuicaoPorAtivoCommand : Command<bool>
    {
        public RecalcularDistribuicaoPorAtivoCommand(Guid usuarioId)
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
