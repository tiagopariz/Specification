using System.Text.RegularExpressions;
using Specification.Domain.ValueObjects;

namespace Specification.Domain.Specifications.ValueObjects
{
    public class EmailValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;

        public EmailValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var email = candidate as Email;

            if (string.IsNullOrEmpty(email?.Address) && !_required)
                return true;

            if ((email?.Address ?? "").Length < Email.AddressMinLength)
                return false;

            if ((email?.Address ?? "").Length > Email.AddressMaxLength)
                return false;

            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email?.Address ?? "", pattern);
        }
    }
}