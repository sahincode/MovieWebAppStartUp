using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class UpdateModel : PageModel
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        [BindProperty]
        public MovieUpdateDto Movie { get; set; } = default!;
        public UpdateModel( IMovieService service ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var movie = await _service.GetById(id);
            if (movie is null) return NotFound();
            Movie =_mapper.Map<MovieUpdateDto>(movie);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                 await _service.UpdateAsync(Movie);
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
