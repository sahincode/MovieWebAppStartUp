using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Data.Repositories.Implementations
{
    public class SeasonRepository : GenericRepository<Season>, ISeasonRepository
    {
        public SeasonRepository(MoviesWebAppContext context) : base(context){}
    }
}
