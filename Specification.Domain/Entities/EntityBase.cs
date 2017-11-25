using System.Collections.Generic;
using Specification.Notifications;
using Specification.Validator.Validations;

namespace Specification.Domain.Entities
{
    public abstract class EntityBase<TContract, TNotification>
        where TContract : Contract, new()
        where TNotification : Notification
    {
        private readonly List<TNotification> _notifications;

        protected EntityBase()
        {
            _notifications = new List<TNotification>();
        }

        public TContract Contract => new TContract();
        public IReadOnlyCollection<TNotification> Notifications => Contract.Join(_notifications);
        public bool IsValid => !(Notifications.Count > 0);

        public void AddNotification(TNotification notification)
        {
            _notifications.Add(notification);
        }
    }
}
