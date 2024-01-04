using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;
namespace MoviesWebApp.Areas.Admin.Pages.AdminGenre
{
    public class DetailsModel : PageModel
    {
        private readonly IGenreService _genreService;

        public Genre  Genre { get; set; } = default!;
        public DetailsModel( IGenreService genreService)
        {
            this._genreService = genreService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var genre = await _genreService.GetById(id);
            if (genre == null) return NotFound();
            else
            {
                Genre = genre;
            }
            return Page();
        }
    }
}
