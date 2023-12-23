using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Enums;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;
using MoviesWebApp.ViewModels;
using NuGet.ProjectModel;

namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class CreateModel : PageModel
    {
        private readonly IMovieService _movieService;

        [BindProperty]
        public MovieCreateDto Movie { get; set; }
        public List<SelectListItem> GenreList { get; set; } = new();
        public CreateModel(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        public IActionResult OnGetAsync()
        {
            var claims = User.Claims;

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
                await _movieService.CreateAsync(Movie);

            }catch(MovieFileFormatException ex) 
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();
            }
            

            return RedirectToPage("./Index");
        }
    }
}
