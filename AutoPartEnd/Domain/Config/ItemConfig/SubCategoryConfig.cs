using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> b)

        {
            b.Property(p => p.SubCategoryName).HasMaxLength(50).IsRequired(true);
            b.HasIndex(p => p.SubCategoryName).IsUnique();
            b.Property(p => p.ImageData).HasColumnType("image");

            b.HasOne(p => p.Category).WithMany(p => p.SubCategories).HasForeignKey(p => p.CategoryId);

        }
    }
}
