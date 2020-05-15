using IHolder.Application.Notifications;
using System.Collections.Generic;

namespace IHolder.Application.Interfaces.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        IEnumerable<Notification> GetNotifications();
        void AddNotification(Notification notification);
    }
}
