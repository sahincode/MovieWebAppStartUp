using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;

using MoviesWebApp.Data.DAL;
using MoviesWebApp.Business.Services.Implementations;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.Exceptions.AboutModelExceptions;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;

namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public List<MovieIndexDto> Movies { get; set; } = new List<MovieIndexDto>();

        public IndexModel(IMovieService movieService ,IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
         {
            
            IEnumerable<Movie>movies  = await  _movieService.GetAll( null ,"MovieGenres");
            if(movies is null) return NotFound();
           foreach (Movie movie in movies)
            {
                MovieIndexDto movieIndex = _mapper.Map<MovieIndexDto>(movie);
                Movies.Add(movieIndex);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody] int id)
        {

            try
            {
                await _movieService.Delete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete(int id)
        {

            try
            {
                await _movieService.ToggleDelete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToAction("OnGet");
        }
    }
}
