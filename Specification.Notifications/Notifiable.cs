using System.Collections.Generic;
using System.Linq;
using Specifications.Domain.Interfaces.Notifications;

namespace Specification.Notifications
{
    public abstract class Notifiable<TEntity> : INotifiable<TEntity> where TEntity : class
    {
        private readonly List<INotification> _notifications;

        protected Notifiable() { _notifications = new List<INotification>(); }

        public IReadOnlyCollection<INotification> Notifications { get { return _notifications; } }

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotification(INotification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<INotification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<INotification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<INotification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(INotifiable<TEntity> item)
        {
            AddNotifications(item.Notifications);
        }

        public void AddNotifications(params INotifiable<TEntity>[] items)
        {
            foreach (var item in items)
                AddNotifications(item);
        }

        public bool Invalid => _notifications.Any();
        public bool Valid => !Invalid;
    }
}
