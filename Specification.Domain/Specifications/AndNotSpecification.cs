using Specification.Domain.Interfaces.Specifications;

namespace Specification.Domain.Specifications
{
    public class AndNotSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndNotSpecification(ISpecification<T> left, 
            ISpecification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T candidate) => 
            (_leftSpecification.IsSatisfiedBy(candidate) && 
             _rightSpecification.IsSatisfiedBy(candidate)) != true;
    }
}