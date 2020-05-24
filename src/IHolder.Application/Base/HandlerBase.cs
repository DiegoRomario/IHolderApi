using MediatR;

namespace IHolder.Application.Base
{
    public class HandlerBase : IHandlerBase
    {
        private readonly IMediator _mediator;
        private bool _hasPublication;
        public HandlerBase(IMediator mediator)
        {
            _hasPublication = false;
            _mediator = mediator;
        }

        public void PublishNotification(string message)
        {
            _mediator.Publish(new Notification(message));
            _hasPublication = true;
        }

        public bool HasNotification()
        {
            return _hasPublication;
        }

    }
}
