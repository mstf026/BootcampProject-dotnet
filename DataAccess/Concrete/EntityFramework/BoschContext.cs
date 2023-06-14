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
            optionsBuilder.UseSqlServer(@"Data Source=myboschproject2612-server.database.windows.net,1433;Initial Catalog=BoschProject;User ID=myboschproject2612-server-admin;Password=2FF2H8A2L7OYD13V$");
        }
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
