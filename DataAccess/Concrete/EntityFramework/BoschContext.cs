using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class BoschContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = tcp:myboschproject2612 - server.database.windows.net, 1433; Initial Catalog = BoschProject; User Id = myboschproject2612 - server - admin@myboschproject2612 - server; Password = 2FF2H8A2L7OYD13V$");
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

        public DbSet<ProductSubpiece> Product_Subpieces { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
