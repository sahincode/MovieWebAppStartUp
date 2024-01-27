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
    public class NewsSlideConfiguration : IEntityTypeConfiguration<NewsSlide>
    {
        public void Configure(EntityTypeBuilder<NewsSlide> builder)
        {
            builder.Property(m => m.Title).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.SubDescription).
                IsRequired().HasMaxLength(300);
            builder.Property(m => m.Description).
                IsRequired().HasMaxLength(1000);
        }
    }
}
