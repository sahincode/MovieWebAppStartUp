using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.AboutDTOs;
using MoviesWebApp.Core.DTOs.GenreDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Areas.Admin.Pages.AdminGenre
{
    public class CreateModel : PageModel
    {
        private readonly MoviesWebAppContext _context;
        private readonly IGenreService _genreService;

        [BindProperty]
        public GenreCreateDto GenreCreateDto { get; set; } = default!;
        public CreateModel(MoviesWebAppContext context , IGenreService genreService)
        {
            _context = context;
            this._genreService = genreService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if(!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _genreService.CreateAsync(GenreCreateDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }
         
            return RedirectToPage("./Index");
        }
    }
}
