namespace Specifications.Domain.Interfaces.Notifications
{
    public interface INotification
    {
        string Property { get; }
        string Message { get; }
    }
}
