using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartEnd.Domain
{
    public class CarModelConfig : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder <CarModel> b)
        {
            
            b.Property(p => p.Name).HasMaxLength(500).IsRequired(true);
            b.HasIndex(p => p.Name).IsUnique();
        }
    }
}
