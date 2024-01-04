using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;


using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class UpdateModel : PageModel
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;

        [BindProperty]
        public MovieUpdateDto Movie { get; set; } = default!;
        public SelectList GenreList { get; set; } 
        public UpdateModel( IMovieService service ,IMapper mapper ,IGenreService genreService)
        {
            this._service = service;
            this._mapper = mapper;
            this._genreService = genreService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var movie = await _service.GetById(id);
            if (movie is null) return NotFound();
            Movie =_mapper.Map<MovieUpdateDto>(movie);

            List<Genre> genres = _genreService.GetAll(g => g.IsDeleted == false ).Result.ToList();
            if (genres != null)
            {
                GenreList = new SelectList(genres, "Id", "Name");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                 await _service.UpdateAsync(id ,Movie);
            }
            catch (MovieFileFormatException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();
             
            }
            return RedirectToPage("./Index");
        }
    }
}
