using Specification.Domain.Interfaces.Specifications;

namespace Specification.Domain.Specifications
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _notSpecification;

        public NotSpecification(ISpecification<T> not)
        {
            _notSpecification = not;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !_notSpecification.IsSatisfiedBy(o);
        }
    }
}