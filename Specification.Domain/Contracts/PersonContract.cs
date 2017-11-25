using Specification.Validator.Validations;

namespace Specification.Domain.Contracts
{
    public class PersonContract : Contract
    {
        public const int NameMaxLength = 254;
        public const int NameMinLength = 1;

        public Contract IsValidName(string name, string property, string message)
        {
            if (name.Length <= NameMinLength || name.Length >= NameMaxLength)
               AddNotification(property, message);

            return this;
        }
    }
}