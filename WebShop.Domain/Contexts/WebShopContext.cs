using Microsoft.EntityFrameworkCore;
using WebShopDomain.Entities;

namespace WebShopDomain.Contexts
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions<WebShopContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(x => x.ProductList)
                .WithMany(x => x.OrderList);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Client)
                .WithMany(x => x.OrderList)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}