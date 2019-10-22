using Microsoft.EntityFrameworkCore;

namespace SportsStore_v1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options){

        }
        public DbSet<Product> Products{get;set;}
    }

}