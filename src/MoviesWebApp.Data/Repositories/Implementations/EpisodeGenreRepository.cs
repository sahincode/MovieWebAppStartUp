using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Data.Repositories.Implementations
{
    public class EpisodeGenreRepository : GenericRepository<EpisodeGenre>, IEpisodeGenreRepository
    {
        public EpisodeGenreRepository(MoviesWebAppContext context) : base(context) { }
    }
}
