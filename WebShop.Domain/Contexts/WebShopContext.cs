using Microsoft.EntityFrameworkCore;
using WebShopDomain.Entities;

namespace WebShopDomain.Contexts
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions<WebShopContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}