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
    public class PrivacyConfiguration :IEntityTypeConfiguration<Privacy>
    {
        public void Configure(EntityTypeBuilder<Privacy> builder)
        {
            builder.Property(m => m.Info).
                 IsRequired().HasMaxLength(8000).HasColumnType("varchar(max)");
        }
    }
}
