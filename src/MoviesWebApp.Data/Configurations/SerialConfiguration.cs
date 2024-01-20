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
    public class SerialConfiguration : IEntityTypeConfiguration<Serial>
    {
        public void Configure(EntityTypeBuilder<Serial> builder)
        {
            builder.Property(m => m.Name).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.Description).
                IsRequired().HasMaxLength(300);
          
        }
    }
}
