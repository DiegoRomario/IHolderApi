namespace IHolder.Application.Base
{
    public interface IHandlerBase
    {
        void PublishNotification(string message);
        bool ValidateCommand<T>(Command<T> command);
    }
}