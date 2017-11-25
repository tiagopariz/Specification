namespace Specification.Notifications
{
    public class Notification
    {
        public Notification(string property, string message, SeverityType severityType = SeverityType.Information)
        {
            Property = property;
            Message = message;
            SeverityType = severityType;
        }

        public string Property { get; private set; }
        public string Message { get; private set; }
        public SeverityType SeverityType { get; private set; }
    }
}
