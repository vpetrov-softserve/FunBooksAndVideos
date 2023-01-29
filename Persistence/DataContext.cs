using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ProductDetails> Products { get; set; }
        public DbSet<Order> Orders {get; set;}

        public DbSet<UsersContentProducts> UsersContentProducts {get; set;}
        public DbSet<UsersMemberships> UsersMemberships {get; set;}
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentProduct>().ToTable(typeof(ContentProduct).ToString());
            modelBuilder.Entity<Membership>().ToTable(typeof(Membership).ToString());
        }
    }
}