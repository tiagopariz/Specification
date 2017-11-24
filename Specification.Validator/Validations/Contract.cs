using Specification.Notifications;
using Specifications.Domain.Interfaces.Notifications;
using Specifications.Domain.Interfaces.Specifications;

namespace Specification.Validator.Validations
{
    public partial class Contract : Notifiable, IContract
    {
        public IContract Requires()
        {
            return this;
        }

        public IContract Join(params INotifiable[] items)
        {
            if (items == null) return this;
            foreach (var notifiable in items)
            {
                if (notifiable.Invalid)
                    AddNotifications(notifiable.Notifications);
            }

            return this;
        }
    }
}
