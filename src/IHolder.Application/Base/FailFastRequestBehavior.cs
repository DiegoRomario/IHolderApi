using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Base
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse> where TResponse : Response
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly IResponse _response;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators, IResponse response)
        {
            _validators = validators;
            _response = response;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                foreach (var failure in failures)
                {
                    _response.Error(failure.ErrorMessage);
                }
                return Task.FromResult(_response as TResponse);
            }

            return  next();
        }
    }
}
