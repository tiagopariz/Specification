using Specification.Domain.Specifications.ValueObjects;

namespace Specification.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int AddressMinLength = 3;
        public const int AddressMaxLength = 255;

        public Email(string address)
        {
            Address = address;
            ValidSpecification = new EmailValidSpecification<object>();
        }

        public string Address { get; }
    }
}