using System;

namespace Specifications.Domain.Entities
{
    public class Person
    {
        public Person(Guid personId, string name)
        {
            PersonId = personId;
            Name = name;
        }

        public Guid PersonId { get; }
        public string Name { get; }
    }
}
