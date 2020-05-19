using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class RecalcularDistribuicaoPorProdutoCommand : Command<bool>
    {
        public RecalcularDistribuicaoPorProdutoCommand(Guid usuarioId)
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
