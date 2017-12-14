namespace Specification.Domain.Entities
{
    public class Category : Entity
    {
        public const int DescriptionMinLength = 1;
        public const int DescriptionMaxLength = 20;

        public Category(int categoryId, string description)
        {
            CategoryId = categoryId;
            Description = description;
        }

        public int CategoryId { get; }
        public string Description { get; }
    }
}