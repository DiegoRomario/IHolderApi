using IHolder.Application.Base;
using IHolder.Domain.DomainObjects;
using MediatR;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Business.Base
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, bool>
         where TRequest : Command<bool>
    {

        private readonly IUser _user;
        private readonly IMediator _mediator;

        public FailFastRequestBehavior(IUser user, IMediator mediator)
        {
            _user = user;
            _mediator = mediator;
        }

        public Task<bool> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<bool> next)
        {
#if !DEBUG
            PropertyInfo propriedade = typeof(TRequest).GetProperty("UsuarioId");

            object valor = propriedade?.GetValue(request, null);

            if (valor != null)
            {
                Guid user = Guid.Parse(valor.ToString());

                if (user != _user.GetUserId())
                {
                    _mediator.Publish(new Notification(message: "O usuário informado não corresponde ao usuário logado"));
                    return Task.FromResult(false);
                }
            }
#endif

            return next();
        }
    }
}
