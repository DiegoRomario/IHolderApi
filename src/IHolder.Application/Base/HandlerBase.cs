using MediatR;

namespace IHolder.Application.Base
{
    public class HandlerBase : IHandlerBase
    {
        private readonly IMediator _mediator;
        public HandlerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void PublishNotification(string message)
        {
            _mediator.Publish(new Notification(message));
        }

    }
}
