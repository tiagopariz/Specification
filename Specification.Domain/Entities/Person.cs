using System;
using System.Collections.Generic;
using Specification.Domain.Contracts;
using Specification.Domain.ValueObjects;
using Specification.Notifications;

namespace Specification.Domain.Entities
{
    public class Person : EntityBase<PersonContract, Notification>
    {
        public const int NameMaxLength = PersonContract.NameMaxLength;
        public const int NameMinLength = PersonContract.NameMinLength;

        public Person(Guid personId, string name, Email email)
        {
            IsValid(name, email);

            PersonId = personId;
            Name = name;
            Email = email;
        }

        private void IsValid(string name, Email email)
        {
            foreach (var notification in Contract.IsValidName(name, "Name", "Nome inválido").Notifications)
                AddNotification(notification);

            foreach (var notification in email.Notifications)
                AddNotification(notification);

            Contract.IsValid();
        }

        public Guid PersonId { get; }
        public string Name { get; }
        public Email Email { get; }
    }
}
