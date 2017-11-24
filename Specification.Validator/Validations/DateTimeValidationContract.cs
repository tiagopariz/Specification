using System;
using Specifications.Domain.Interfaces.Specifications;

namespace Specification.Validator.Validations
{
    public partial class Contract
    {
        public IContract IsGreaterThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val <= comparer)
                AddNotification(property, message);

            return this;
        }

        public IContract IsGreaterOrEqualsThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val < comparer)
                AddNotification(property, message);

            return this;
        }

        public IContract IsLowerThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val >= comparer)
                AddNotification(property, message);

            return this;
        }

        public IContract IsLowerOrEqualsThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val > comparer)
                AddNotification(property, message);

            return this;
        }

        public IContract IsBetween(DateTime val, DateTime from, DateTime to, string property, string message)
        {
            if (!(val > from && val < to))
                AddNotification(property, message);

            return this;
        }
    }
}