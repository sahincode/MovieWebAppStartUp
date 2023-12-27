using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.AboutDTOs;
using MoviesWebApp.Core.DTOs.GenreDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Areas.Admin.Pages.AdminGenre
{
    public class UpdateModel : PageModel
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public UpdateModel( IGenreService genreService ,IMapper mapper)
        {
            this._genreService = genreService;
            this._mapper = mapper;
        }

        [BindProperty]
        public GenreUpdateDto GenreUpdateDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var genre = await  _genreService.Get(a => a.Id == id && a.IsDeleted == false);
            if (genre == null)
            {
                return NotFound();
            }
            GenreUpdateDto = _mapper.Map<GenreUpdateDto>(genre);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id )
        {
            if (!ModelState.IsValid) return Page();
            
            if(id == null) return NotFound();
            try
            {
                await _genreService.UpdateAsync(id, GenreUpdateDto);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }

      
    }
}
