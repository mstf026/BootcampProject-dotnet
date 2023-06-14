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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-GVKRO6C;Database=BoschProject;Trusted_Connection=true;TrustServerCertificate=True");
        //}
        public BoschContext(DbContextOptions<BoschContext> options) : base(options)
        {
        }

        public BoschContext()
        {
        }


        public DbSet<Department> Departments { get; set; } = default!;

        public DbSet<Product> Products { get; set; }

        public DbSet<Subpiece> Subpieces { get; set; }

        public DbSet<Product_Subpiece> Product_Subpieces { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Station> Stations { get; set; }

    }
}
