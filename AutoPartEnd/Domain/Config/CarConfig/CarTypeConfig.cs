using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class CarTypeConfig : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> b)
        {
           
            b.Property(p => p.Name).HasMaxLength(500).IsRequired(true);

            b.Property(p => p.ModelId).IsRequired(true);
            b.HasOne(p => p.Model).WithMany(p => p.CarTypes).HasForeignKey(p => p.ModelId);
      
        }
    }
}

