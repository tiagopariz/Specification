namespace Specification.Notifications
{
    public class Notification
    {
        public Notification(string property,
                            string message,
                            SeverityType severityType = SeverityType.Information)
        {
            Property = property;
            Message = message;
            SeverityType = severityType;
        }

        public string Property { get; }
        public string Message { get; }
        public SeverityType SeverityType { get; }
    }
}