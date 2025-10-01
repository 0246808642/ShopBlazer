using Microsoft.EntityFrameworkCore;
using ShopBlazor.Api.Entities;

namespace ShopBlazor.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<ItemCart>? ItemCarts { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
