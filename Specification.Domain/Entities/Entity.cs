using Specification.Domain.Specifications;

namespace Specification.Domain.Entities
{
    public abstract class Entity
    {
        protected CompositeSpecification<object> ValidSpecification = null;

        public bool IsValid()
        {
            return ValidSpecification?.IsSatisfiedBy(this) ?? true;
        }
    }
}