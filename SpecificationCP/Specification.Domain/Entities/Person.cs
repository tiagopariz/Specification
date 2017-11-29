using System;
using Specification.Domain.ValueObjects;

namespace Specification.Domain.Entities
{
    public class Person
    {
        public Person(Guid personId, string name, Email email, Category category)
        {
            PersonId = personId;
            Name = name;
            Email = email;
            Category = category;
        }

        public Guid PersonId { get;}
        public string Name { get; }
        public Email Email { get; }
        public Category Category { get; }
    }
}
