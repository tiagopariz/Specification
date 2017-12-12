using Specification.Domain.Entities;

namespace Specification.Domain.Specifications.Entities
{
    public class PersonCustomerSpecification<T> : CompositeSpecification<T>
    {
        private readonly int _categoryId;

        public PersonCustomerSpecification()
        {
            _categoryId = 1;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var person = candidate as Person;
            return person != null && person.Category?.CategoryId == _categoryId;
        }
    }
}