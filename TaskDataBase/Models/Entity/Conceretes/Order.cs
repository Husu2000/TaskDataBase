using TaskDataBase.Models.Entity.Abstracts;

namespace TaskDataBase.Models.Entity.Conceretes
{
    public class Order : BaseEntity
    {
        public int? Quantity { get; set; }
        public int? TotalPrice { get; set; }
        public List<Product>? Products { get; set; }

    }
}
