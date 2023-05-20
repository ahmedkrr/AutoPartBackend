using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class ResetPasswordConfig : IEntityTypeConfiguration<ResetPassword>
    {
        public void Configure(EntityTypeBuilder<ResetPassword> b)
        {
            b.HasOne(p => p.UserProfile).WithMany(p => p.ResetPasswords).HasForeignKey(p => p.UserProfileId);



        }
    }
}
