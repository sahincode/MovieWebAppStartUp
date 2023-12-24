using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Enums;

namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class UpdateModel : PageModel
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        [BindProperty]
        public MovieUpdateDto Movie { get; set; } = default!;
        public List<SelectListItem> GenreList { get; set; } = new();
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

            foreach (Genre genreEnum in Enum.GetValues(typeof(Genre)))
                GenreList.Add(new SelectListItem() { Text = genreEnum.ToString(), Value = ((int)genreEnum).ToString() });
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
