using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Data.Configurations
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.Property(m => m.Country).
               IsRequired().HasMaxLength(70);
            builder.Property(m => m.Name).
              IsRequired().HasMaxLength(100);
            builder.Property(m => m.ImageUrl).
              IsRequired().HasMaxLength(100);
            builder.HasOne(s => s.Serial).WithMany(s => s.Seasons);
        }
    }
}
