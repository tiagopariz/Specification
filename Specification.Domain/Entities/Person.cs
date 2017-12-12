using System;
using Specification.Domain.Specifications.Entities;
using Specification.Domain.ValueObjects;

namespace Specification.Domain.Entities
{
    public class Person : Entity
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 50;

        public Person(Guid personId, string name, Email email, Category category)
        {
            PersonId = personId;
            Name = name;
            Email = email;
            Category = category;
            Specification = new PersonValidSpecification<object>();
        }

        public Guid PersonId { get;}
        public string Name { get; }
        public Email Email { get; }
        public Category Category { get; }
    }
}