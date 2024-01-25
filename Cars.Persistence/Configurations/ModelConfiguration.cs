using Cars.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Persistence.Configurations
{
    internal sealed class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable(nameof(Model));
            builder.HasKey(model => model.Id);
            builder.Property(model => model.Id).ValueGeneratedOnAdd();
            builder.Property(model => model.Name).HasMaxLength(50);
            builder.Property(model => model.DateCreated).IsRequired();
        }
    }
}
