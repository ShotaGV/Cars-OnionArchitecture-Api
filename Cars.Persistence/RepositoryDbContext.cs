using Cars.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public sealed class RepositoryDbContext :DbContext
    {
        public RepositoryDbContext(DbContextOptions options) 
            : base(options) 
        { 
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        

    }
}
