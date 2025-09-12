using TaskDataBase.Models.Entity.Abstracts;

namespace TaskDataBase.Models.Entity.Conceretes
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
