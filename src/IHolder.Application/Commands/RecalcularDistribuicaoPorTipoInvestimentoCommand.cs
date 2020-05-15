using IHolder.Application.Base;
using MediatR;
using System;

namespace IHolder.Application.Commands
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
