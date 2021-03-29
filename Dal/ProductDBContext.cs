using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {

        }
    
        public DbSet<Product> CtProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //product code must be unique
            modelBuilder.Entity<Product>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Product>().ToTable("CtProduct");
        }

        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(local);Database=BilicraDB;Integrated Security=false;User ID=sa;Password=Alper1998;",
                option =>
                {
                    option.EnableRetryOnFailure();
                });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
