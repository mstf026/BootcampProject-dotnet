using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class BoschContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GVKRO6C;Database=BoschProject;Trusted_Connection=true;TrustServerCertificate=True");
        }
        public BoschContext(DbContextOptions<BoschContext> options) : base(options)
        {
        }

        public BoschContext()
        {
              void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-GVKRO6C;Database=BoschProject;Trusted_Connection=true;TrustServerCertificate=True");
            }
        }


        public DbSet<Department> Department { get; set; } = default!;

        public DbSet<Product> Product { get; set; }

        public DbSet<Subpiece> Subpiece { get; set; }

        public DbSet<Product_Subpiece> Product_Subpiece { get; set; }
        public DbSet<Order> Order { get; set; }
        
    }
}
