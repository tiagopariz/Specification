using System.Collections.Generic;
using Specification.Notifications;
using Specification.Validator.Validations;

namespace Specification.Domain.ValueObjects
{
    public abstract class ValueObjectBase<TContract, TNotification>
        where TContract : Contract, new()
        where TNotification : Notification
    {
        private readonly List<TNotification> _notifications;

        protected ValueObjectBase()
        {
            _notifications = new List<TNotification>();
        }

        public TContract Contract => new TContract();
        public IReadOnlyCollection<TNotification> Notifications => Contract.Join(_notifications);
        public abstract bool Required { get; }

        public void AddNotification(TNotification notification)
        {
            _notifications.Add(notification);
        }
    }
}