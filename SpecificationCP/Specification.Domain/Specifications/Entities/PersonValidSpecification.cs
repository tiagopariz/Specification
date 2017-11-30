using Specification.Domain.Entities;
using Specification.Domain.ValueObjects;

namespace Specification.Domain.Specifications.Entities
{
    public class PersonValidSpecification<T> : CompositeSpecification<T>
    {
        public override bool IsSatisfiedBy(T o)
        {
            var person = o as Person;

            var personNameSpecification = new PersonNameValidSpecification<Person>(true);
            if (!personNameSpecification.IsSatisfiedBy(person))
                return false;

            var emailSpecification = new EmailValidSpecification<Email>(false);
            if (!emailSpecification.IsSatisfiedBy(person?.Email))
                return false;

            return true;
        }
    }
}
