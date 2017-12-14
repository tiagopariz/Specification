using System;
using System.Collections.Generic;
using System.Linq;
using Specification.Domain.Entities;
using Specification.Domain.Interfaces.Specifications;
using Specification.Domain.Specifications;
using Specification.Domain.Specifications.Entities;
using Specification.Domain.ValueObjects;

namespace Specification.Prompt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // https://www.codeproject.com/Articles/670115/Specification-pattern-in-Csharp

            // People list
            var people = new List<Person> {
                new Person(Guid.NewGuid(), "Tiago1", new Email("tiago1@gmail.com"), new Category(2, "Partner")),
                new Person(Guid.NewGuid(), "Tiago2", new Email("tiago2@gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Tiago3", new Email("tiago3@gmail.com"), new Category(2, "Partner")),
                new Person(Guid.NewGuid(), "Tiago4", new Email("tiago4_gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Tiago5", new Email("tiago5@gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Tiago6", new Email("tiago6@gmail.com"), new Category(1, "Customer")),
                new Person(Guid.NewGuid(), "Tiago7", new Email("tiago7@gmail.com"), null) };

            ISpecification<Person> customersSpecification = new ExpressionSpecification<Person>(x => x.Category?.CategoryId == 1);
            ISpecification<Person> partnerSpecification = new ExpressionSpecification<Person>(x => x.Category?.CategoryId == 2);
            ISpecification<Person> nullSpecification = new ExpressionSpecification<Person>(x => x.Category == null);

            var allWithCategorySpecification = customersSpecification.Or(partnerSpecification);
            var includeNull = allWithCategorySpecification.Or(nullSpecification);

            // Validations
            ISpecification<Person> validSpecification = new PersonValidSpecification<Person>();

            Console.WriteLine(":: ALL PEOPLE ::");

            foreach (var item in people)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: CUSTOMER ::");

            ISpecification<Person> personCustomersSpecification = new PersonCustomerSpecification<Person>();

            var customer = people.FindAll(x => personCustomersSpecification.IsSatisfiedBy(x));

            foreach (var item in customer)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: PARTNER ::");

            var partners = people.FindAll(x => partnerSpecification.IsSatisfiedBy(x));

            foreach (var item in partners)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: WITHOUT CATEGORY ::");

            var nullCategory = people.FindAll(x => nullSpecification.IsSatisfiedBy(x));

            foreach (var item in nullCategory)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.WriteLine("");
            Console.WriteLine(":: WITH AND WITHOUT CATEGORY ::");

            var allAndNullCategory = people.FindAll(x => includeNull.IsSatisfiedBy(x));

            foreach (var item in allAndNullCategory)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine(":: ALL VALID ::");

            var validPeople = people.Where(x => validSpecification.IsSatisfiedBy(x));

            foreach (var item in validPeople)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            Console.WriteLine(":: VALID CUSTOMERS ::");

            var validCustomers = people.Where(x => validSpecification.IsSatisfiedBy(x) && customersSpecification.IsSatisfiedBy(x));

            foreach (var item in validCustomers)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine(":: VALID PARTNERS ::");

            var validPartners = people.Where(x => validSpecification.IsSatisfiedBy(x) && partnerSpecification.IsSatisfiedBy(x));

            foreach (var item in validPartners)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine(":: INVALID ::");

            var invalidPeople = people.Where(x => !validSpecification.IsSatisfiedBy(x));

            foreach (var item in invalidPeople)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine(":: ISVALID ::");

            var isvalidPeople = people.Where(x => x.IsValid());

            foreach (var item in isvalidPeople)
            {
                Console.WriteLine(item.PersonId + " | " + item.Name + " | " + item.Email.Address + " | " + item.Category?.Description);
            }

            Console.ReadKey();
        }
    }
}