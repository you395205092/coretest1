using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyService.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_Users");
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.UserPass).IsRequired().HasMaxLength(50);
            builder.HasQueryFilter(u => u.IsDeleted == false);
        }
    }
}
