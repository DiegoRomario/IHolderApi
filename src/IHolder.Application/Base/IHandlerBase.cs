namespace IHolder.Application.Base
{
    public interface IHandlerBase
    {
        public bool HasNotification();
        void PublishNotification(string message);
    }
}