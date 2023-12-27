using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;
namespace MoviesWebApp.Data.DAL
{
    public class MoviesWebAppContext : IdentityDbContext<ApplicationUser>
    {
        public MoviesWebAppContext(DbContextOptions<MoviesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = default!;

        public DbSet<About> Abouts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }


        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in datas)
            {
                var entity = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Added:
                        entity.CreationTime = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Modified:
                        entity.UpdateTime = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Deleted:
                        entity.DeletedTime = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Detached:
                        entity.UpdateTime = DateTime.UtcNow.AddHours(4);
                        break;

                }


            }
            return base.SaveChanges();
        }


    }
}
