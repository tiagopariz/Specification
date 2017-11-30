namespace Specification.Domain.ValueObjects
{
    public class Email
    {
        public const int AddressMinLength = 3;
        public const int AddressMaxLength = 255;

        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; }
    }
}
