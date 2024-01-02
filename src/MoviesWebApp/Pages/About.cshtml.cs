using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Pages
{

    public class LogoModel : PageModel
    {
        private readonly IEmailService _emailServices;
        private readonly MoviesWebAppContext _context;

        
        public LogoModel(
            MoviesWebAppContext context, IEmailService emailServices)
        {
           
            _context=context;
            _emailServices = emailServices;
        }
        //public LogoPageInfo LogoPageInfo { get; set; } = default!;
        public IList<Movie> Movies { get; set; } = default!;
        public IList<About> LogoPageInfos { get; set; } = default!;
        

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                Movies = await _context.Movies.ToListAsync();
                LogoPageInfos = await _context.Abouts.ToListAsync();
            }
        }
        

    }
}