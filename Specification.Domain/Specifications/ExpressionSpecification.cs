using System;

namespace Specification.Domain.Specifications
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private readonly Func<T, bool> _expression;

        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentException();

            _expression = expression;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            _expression(candidate);
    }
}