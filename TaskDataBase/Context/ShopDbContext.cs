using Microsoft.EntityFrameworkCore;
using TaskDataBase.Models.Entity.Conceretes;

namespace TaskDataBase.Context
{
   public class ShopDbContext:DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
