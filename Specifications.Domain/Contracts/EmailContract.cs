using Specification.Validator.Validations;

namespace Specifications.Domain.Contracts
{
    public class EmailContract : Contract
    {
        public const int AddressMaxLength = 254;
        public const int AddressMinLength = 3;

        public Contract IsEmail(string email, string property, string message)
        {
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            var result = Matchs(email, pattern, property, message);
            return result;
        }

        public Contract IsEmailOrEmpty(string email, string property, string message)
        {
            return string.IsNullOrEmpty(email)
                        ? this 
                        : IsEmail(email, property, message);
        }
    }
}
