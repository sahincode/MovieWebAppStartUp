using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).
                IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).
               IsRequired().HasMaxLength(300); 
            builder.Property(m => m.Actors).
                IsRequired().HasMaxLength(70); 
            builder.Property(m => m.ImageURL).
                IsRequired().HasMaxLength(100); 
            builder.Property(m => m.VideoURL).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.Country).
                IsRequired().HasMaxLength(100);
            builder.Property(m => m.Director).
                IsRequired().HasMaxLength(70);
            builder.Property(m => m.Duration).IsRequired();
            builder.Property(m => m.ReleaseDate).IsRequired().HasColumnType("date");


        }
    }
}
