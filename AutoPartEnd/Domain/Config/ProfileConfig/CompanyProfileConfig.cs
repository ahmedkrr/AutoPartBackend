using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class CompanyProfileConfig : IEntityTypeConfiguration<CompanyProfile>
    {
        public void Configure(EntityTypeBuilder<CompanyProfile> b)
        {
            
            b.Property(p => p.Name).HasMaxLength(250).IsRequired(true);
            b.Property(p => p.CompanyPhoneNumber).HasMaxLength(20).IsRequired(true);
            b.Property(p => p.Address).HasMaxLength(250).IsRequired(true);
 
        }
    }
}
