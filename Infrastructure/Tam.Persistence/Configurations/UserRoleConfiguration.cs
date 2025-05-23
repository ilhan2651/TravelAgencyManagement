using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(x => x.User)
                   .WithMany(u => u.UserRoles)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Role)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(x => x.RoleId);
        }
    }

}
