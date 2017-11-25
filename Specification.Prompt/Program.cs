using System;
using Specification.Domain.Entities;
using Specification.Domain.ValueObjects;

namespace Specification.Prompt
{
    class Program
    {
        static void Main(string[] args)
        {
            var validPerson = new Person(Guid.NewGuid(), "Tiago", new Email("tiago@gmail.com"));

            foreach (var notification in validPerson.Notifications)
            {
                Console.WriteLine($"{notification.Property} - {notification.Message}");
            }

            Console.WriteLine($"\nVálido: {validPerson.IsValid}\n");

            //var invalidPersonName = new Person(Guid.NewGuid(), "", new Email("tiago@gmail.com"));

            //foreach (var notification in invalidPersonName.Notifications)
            //{
            //    Console.WriteLine($"{notification.Property} - {notification.Message}");
            //}

            //var invalidPersonEmail = new Person(Guid.NewGuid(), "Tiago", new Email("tiago_gmail.com"));

            //foreach (var notification in invalidPersonEmail.Notifications)
            //{
            //    Console.WriteLine($"{notification.Property} - {notification.Message}");
            //}

            var invalidPersonNameEmail = new Person(Guid.NewGuid(), "", new Email("tiago_gmail.com"));

            foreach (var notification in invalidPersonNameEmail.Notifications)
            {
                Console.WriteLine($"{notification.Property} - {notification.Message}");
            }

            Console.WriteLine($"\nVálido: {invalidPersonNameEmail.IsValid}\n");

            Console.ReadKey();
        }
    }
}
