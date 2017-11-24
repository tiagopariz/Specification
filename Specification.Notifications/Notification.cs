using Specifications.Domain.Interfaces.Notifications;

namespace Specification.Notifications
{
    public sealed class Notification : INotification
    {
        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; private set; }
        public string Message { get; private set; }
    }
}
