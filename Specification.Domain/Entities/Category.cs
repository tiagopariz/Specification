namespace Specification.Domain.Entities
{
    public class Category : Entity
    {
        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public int CategoryId { get; }
        public string Name { get; }
    }
}