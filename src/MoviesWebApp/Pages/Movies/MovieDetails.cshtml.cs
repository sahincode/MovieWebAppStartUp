using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Pages.Movies
{
    public class MovieDetailsModel : PageModel
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public MovieIndexDto Movie { get; set; } = default!;
        public MovieDetailsModel( IMovieService service ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<IActionResult> OnGet(int ? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var movie = await _service.Get(m => m.Id == id && m.IsDeleted == false, "MovieGenres");
            
            if (movie == null)
            {
                return NotFound();
            }
            else
            {

                Movie = _mapper.Map<MovieIndexDto>(movie);

               
            }
            return Page();
        }
    }
}
