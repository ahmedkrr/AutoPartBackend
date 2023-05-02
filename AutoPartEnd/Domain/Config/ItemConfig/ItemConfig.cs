using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> b)
        {
            b.Property(p => p.Name).HasMaxLength(50).IsRequired(true);
            b.Property(p => p.ImageData).HasColumnType("image");
            b.Property(p => p.Discription).HasMaxLength(1000).IsRequired(true);

        }
    }
}
