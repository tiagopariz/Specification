using System.Collections.Generic;
using Specification.Notifications;
using Specification.Validator.Validations;

namespace Specifications.Domain.ValueObjects
{
    public abstract class ValueObjectBase<TContract, TNotification>
        where TContract : Contract
        where TNotification : Notification
    {
        private readonly List<TNotification> _notifications;

        protected ValueObjectBase()
        {
            _notifications = null;
        }

        public TContract Contract { get; set; }
        public IReadOnlyCollection<TNotification> Notifications => Contract.Join(_notifications);

        public void AddNotification(TNotification notification)
        {
            _notifications.Add(notification);
        }
    }
}
