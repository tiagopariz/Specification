using Specifications.Domain.Interfaces.Specifications;

namespace Specification.Validator.Validations
{
    public partial class Contract
    {
        public IContract IsTrue(bool val, string property, string message)
        {
            if (!val)
                AddNotification(property, message);

            return this;
        }

        public IContract IsFalse(bool val, string property, string message)
        {
            if (val)
                AddNotification(property, message);

            return this;
        }
    }
}
