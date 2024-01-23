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
    public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.Property(m => m.Actors).
                IsRequired().HasMaxLength(70);
            builder.Property(m => m.Name).
                IsRequired().HasMaxLength(70);
            builder.Property(m => m.ImageURL).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.VideoURL).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.Director).
                IsRequired().HasMaxLength(70);
            builder.Property(m => m.Duration).IsRequired();
            builder.Property(m => m.ReleaseDate).IsRequired().HasColumnType("date");
            builder.HasOne(e => e.Season).WithMany(s => s.Episodes);
        }
    }
}
