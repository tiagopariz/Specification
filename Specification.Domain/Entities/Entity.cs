using Specification.Domain.Specifications;

namespace Specification.Domain.Entities
{
    public abstract class Entity
    {
        protected CompositeSpecification<object> Specification = null;

        public bool IsValid()
        {
            return Specification.IsSatisfiedBy(this);
        }
    }
}
