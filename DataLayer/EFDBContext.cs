using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }

        public DbSet<Directory> Directory { get; set; }
        public DbSet<Material> Material { get; set; }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-17CEBQV; Database=loftblogASPCoreDb; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=True;", b=> b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
