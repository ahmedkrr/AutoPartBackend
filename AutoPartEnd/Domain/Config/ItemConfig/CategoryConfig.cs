using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> b)
        {
            b.Property(p => p.CategoryName).HasMaxLength(60).IsRequired(true);
            b.HasIndex(p => p.CategoryName).IsUnique();
            b.Property(p => p.ImageData).HasColumnType("image");
        }
    }
}
