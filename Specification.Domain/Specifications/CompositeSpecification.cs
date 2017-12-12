using Specification.Domain.Interfaces.Specifications;

namespace Specification.Domain.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);
        public ISpecification<T> And(ISpecification<T> specification) => 
            new AndSpecification<T>(this, specification);
        public ISpecification<T> AndNot(ISpecification<T> specification) => 
            new AndNotSpecification<T>(this, specification);
        public ISpecification<T> Or(ISpecification<T> specification) =>
            new OrSpecification<T>(this, specification);
        public ISpecification<T> OrNot(ISpecification<T> specification) =>
            new OrNotSpecification<T>(this, specification);
        public ISpecification<T> Not(ISpecification<T> specification) =>
            new NotSpecification<T>(specification);
    }
}