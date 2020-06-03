using FluentValidation;
using IHolder.Domain.DomainObjects;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Base
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, bool>
         where TRequest : Command<bool>
    {

        private readonly IUser _user;
        private readonly IMediator _mediator;
        private readonly IEnumerable<IValidator> _validators;

        public FailFastRequestBehavior(IUser user, IMediator mediator, IEnumerable<IValidator<TRequest>> validators)
        {
            _user = user;
            _mediator = mediator;
            _validators = validators;
        }

        public Task<bool> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<bool> next)
        {

            PropertyInfo propriedade = typeof(TRequest).GetProperty("UsuarioId");
            propriedade?.SetValue(request, _user.GetUserId());
            //object valor = propriedade?.GetValue(request, null);

            //if (valor != null)
            //{
            //    Guid user = Guid.Parse(valor.ToString());

            //    if (user != _user.GetUserId())
            //    {
            //        _mediator.Publish(new Notification(message: "O usuário informado não corresponde ao usuário logado"));
            //        return Task.FromResult(false);
            //    }
            //}


            var falhas = _validators.Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (falhas.Any())
            {
                foreach (var falha in falhas)
                {
                    _mediator.Publish(new Notification(message: falha.ErrorMessage));                    
                }
                return Task.FromResult(false);
            }

            return next();
        }
    }
}
