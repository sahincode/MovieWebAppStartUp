using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;

using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public List<MovieIndexDto> Movies { get; set; } = default!;

        public IndexModel(IMovieService movieService ,IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Movie>movies  = await  _movieService.GetAll( null ,null);
            if(movies is null) return NotFound();
           foreach (Movie movie in movies)
            {
                MovieIndexDto movieIndex = _mapper.Map<MovieIndexDto>(movie);
                Movies.Add(movieIndex);
            }
            return Page();
        }
    }
}
