using AutoPartEnd.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> b)
        {
           
            b.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
            b.Property(p => p.Email).HasMaxLength(100).IsRequired(true);
            b.Property(p => p.Password).HasMaxLength(500).IsRequired(true);
            b.Property(p => p.PhoneNumber).HasMaxLength(20).IsRequired(true);
            b.Property(p => p.Role).HasDefaultValue(UserRole.undefined).IsRequired(true);
            b.HasIndex(p => p.Email).IsUnique();

            b.Property(p => p.CompanyProfileId).IsRequired(false);
            b.HasOne(p => p.CompanyProfile).WithMany(p => p.userProfiles).HasForeignKey(p => p.CompanyProfileId);
        }
    }
}
