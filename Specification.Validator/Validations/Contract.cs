using System.Collections.Generic;
using System.Text.RegularExpressions;
using Specification.Notifications;

namespace Specification.Validator.Validations
{
    public class Contract
    {
        public Contract()
        {
            Notifications = new List<Notification>();
        }

        public Contract Requires()
        {
            return this;
        }

        public List<Notification> Notifications { get; }

        public Contract Matchs(string text, string pattern, string property, string message)
        {
            if (!Regex.IsMatch(text ?? "", pattern))
                AddNotification(property, message);

            return this;
        }

        public IReadOnlyCollection<TNotification> Join<TNotification>(List<TNotification> notifications) 
            where TNotification : Notification
        {
            var newNotifications = new List<TNotification>();
            foreach (var notification in notifications)
            {
                newNotifications.Add(notification);
            }
            return newNotifications;
        }

        public void AddNotification(string property, string message)
        {
            Notifications.Add(new Notification(property, message));
        }

        public bool IsValid()
        {
            return Notifications.Count <= 0;
        }

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
    }
}
