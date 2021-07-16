using Microsoft.EntityFrameworkCore;
using Rookie.MyEcommerce.Entities.CartAggregate;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using Rookie.MyEcommerce.DataAccessors.Configuration;
using System.Reflection;

namespace Rookie.MyEcommerce.DataAccessors.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem>  CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
