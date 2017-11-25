using System.Collections.Generic;
using System.Linq;
using Specification.Notifications;

namespace Specification.Validator.Validations
{
    public class Contract
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        public List<Notification> Notifications => _notifications;

        public IReadOnlyCollection<TNotification> Join<TNotification>(List<TNotification> notifications) 
            where TNotification : Notification
        {
            return notifications.ToList();
        }

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public bool IsValid()
        {
            return Notifications.Count <= 0;
        }
    }
}
