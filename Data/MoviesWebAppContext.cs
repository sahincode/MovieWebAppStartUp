using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Models;
using MoviesWebApp.Models.LogoinfoModel;

namespace MoviesWebApp.Data
{
    public class MoviesWebAppContext : IdentityDbContext { 
        public MoviesWebAppContext (DbContextOptions<MoviesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesWebApp.Models.Movies> Movies { get; set; } = default!;

        public DbSet<MoviesWebApp.Models.LogoinfoModel.LogoPageInfo>? LogoPageInfo { get; set; }
    }
}
