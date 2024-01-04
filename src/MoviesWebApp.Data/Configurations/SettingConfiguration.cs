using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Data.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(m => m.Address).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.Contact).
                IsRequired().HasMaxLength(50);
            builder.Property(m => m.Email).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.FaceUrl).
                IsRequired().HasMaxLength(200);
            builder.Property(m => m.XUrl).
                IsRequired().HasMaxLength(200);
            builder.Property(m => m.WhatUrl).
                IsRequired().HasMaxLength(200);
            builder.Property(m => m.InstaUrl).
              IsRequired().HasMaxLength(200);
        }
    }
}
