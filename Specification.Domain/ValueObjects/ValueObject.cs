using Specification.Domain.Specifications;

namespace Specification.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected CompositeSpecification<object> ValidSpecification = null;

        public bool IsValid()
        {
            return ValidSpecification.IsSatisfiedBy(this);
        }
    }
}