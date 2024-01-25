using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain.Entities;

namespace Cars.Persistence.Configurations
{
    internal sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable(nameof(Brand));

            builder.HasKey(brand => brand.Id);

            builder.Property(model => model.Id).ValueGeneratedOnAdd();

            builder.Property(brand => brand.Name).HasMaxLength(60);

            builder.HasMany(brand => brand.Models)
                .WithOne()
                .HasForeignKey(model => model.BrandId)
                .OnDelete(DeleteBehavior.Cascade);
                    
        }
    }
}
