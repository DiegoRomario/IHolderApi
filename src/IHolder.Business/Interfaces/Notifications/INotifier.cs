using IHolder.Business.Notifications;
using System.Collections.Generic;

namespace IHolder.Business.Interfaces.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        IEnumerable<Notification> GetNotifications();
        void AddNotification(Notification notification);
    }
}
