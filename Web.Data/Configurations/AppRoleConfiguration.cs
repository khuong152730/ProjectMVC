﻿using System;
using System.Collections.Generic;
using System.Text;

using Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web.Data.Configurations
{
   public class AppRoleConfiguration:IEntityTypeConfiguration<AppRole>
    {
        public void Configure (EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRoles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(256);
        }
    }
}
