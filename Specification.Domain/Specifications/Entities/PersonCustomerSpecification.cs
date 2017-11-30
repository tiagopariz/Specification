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

        public override bool IsSatisfiedBy(T o)
        {
            var person = o as Person;
            return person != null && person.Category?.CategoryId == _categoryId;
        }
    }
}
