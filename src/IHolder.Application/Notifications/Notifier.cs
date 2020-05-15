using IHolder.Application.Interfaces.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IHolder.Application.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public IEnumerable<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
