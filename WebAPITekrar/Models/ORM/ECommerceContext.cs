using Microsoft.EntityFrameworkCore;

namespace WebAPITekrar.Models.ORM
{
    public class ECommerceContext : DbContext
    {
      
        //i get the connection string from appsettings.json
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }



        public DbSet<Product> Products { get; set; }
    }
}
