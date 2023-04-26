using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class ManufactureConfig : IEntityTypeConfiguration<ManufactureYear>
    {
        public void Configure(EntityTypeBuilder<ManufactureYear> b)
        {
           
            b.Property(p => p.Year).IsRequired(true);

            b.Property(p => p.TypeId).IsRequired(true);
            b.HasOne(p => p.Types).WithMany(p => p.ManufactureYears).HasForeignKey(p => p.TypeId);
        }

    }
}
