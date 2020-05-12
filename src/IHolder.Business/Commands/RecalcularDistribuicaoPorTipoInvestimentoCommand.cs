using IHolder.Business.Base;
using MediatR;
using System;

namespace IHolder.Business.Commands
{
    public class RecalcularDistribuicaoPorTipoInvestimentoCommand : IRequest<Response>
    {
        public RecalcularDistribuicaoPorTipoInvestimentoCommand(Guid usuarioId)
        {
            this.UsuarioId = usuarioId;
        }
        public Guid UsuarioId { get; set; }

    }
}
