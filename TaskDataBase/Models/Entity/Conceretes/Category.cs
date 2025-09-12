using TaskDataBase.Models.Entity.Abstracts;

namespace TaskDataBase.Models.Entity.Conceretes
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }

    }

}
