using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Data.DAL
{
    public class MoviesWebAppContext : IdentityDbContext<ApplicationUser> { 
        public MoviesWebAppContext (DbContextOptions<MoviesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesWebApp.Core.Models.Movie> Movies { get; set; } = default!;

        public DbSet<LogoPageInfo> LogoPageInfo { get; set; }
        

    }
}
