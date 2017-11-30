using Specification.Domain.Entities;

namespace Specification.Domain.Specifications.Entities
{
    public class PersonNameValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;

        public PersonNameValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T o)
        {
            var person = o as Person;

            if (string.IsNullOrEmpty(person?.Name) && !_required)
                return true;

            if ((person?.Name ?? "").Length < Person.NameMinLength)
                return false;

            if ((person?.Name ?? "").Length > Person.NameMaxLength)
                return false;

            return true;
        }
    }
}
