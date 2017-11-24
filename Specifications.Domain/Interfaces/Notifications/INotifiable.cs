using System.Collections.Generic;

namespace Specifications.Domain.Interfaces.Notifications
{
    public interface INotifiable<TEntity> where TEntity : class
    {
        IReadOnlyCollection<INotification> Notifications { get; }
        bool Invalid { get; }
        bool Valid { get; }
        void AddNotification(string property, string message);
        void AddNotification(INotification notification);
        void AddNotifications(IReadOnlyCollection<INotification> notifications);
        void AddNotifications(IList<INotification> notifications);
        void AddNotifications(ICollection<INotification> notifications);
        void AddNotifications(INotifiable<TEntity> item);
        void AddNotifications(params INotifiable<TEntity>[] items);
    }
}
