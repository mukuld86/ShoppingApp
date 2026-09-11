using Microsoft.EntityFrameworkCore;
using ShoppingDAL.Models;

namespace ShoppingDAL
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MUKUL-PC\\SQLEXPRESS;Database=ShoppingApp;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
