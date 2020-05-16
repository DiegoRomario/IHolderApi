using MediatR;
using System;
namespace IHolder.Application.Base
{
    public class Notification : INotification
    {
        public DateTime Timestamp { get; private set; }
        public Notification(string message)
        {
            Timestamp = DateTime.Now;
            Message = message;
        }

        public string Message { get;}
    }
}
