using Specifications.Domain.Interfaces.Notifications;

namespace Specifications.Domain.Interfaces.Specifications
{
    public interface IContract
    {
        IContract Requires();

        IContract Join(params INotifiable[] items);
    }
}
