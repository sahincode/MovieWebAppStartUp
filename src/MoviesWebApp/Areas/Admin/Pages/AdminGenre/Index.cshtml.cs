using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;

namespace MoviesWebApp.Areas.Admin.Pages.AdminGenre
{
    public class IndexModel : PageModel
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public IndexModel(IGenreService genreService, IMapper mapper)
        {
            this._genreService = genreService;
            this._mapper = mapper;
        }

        public IList<GenreIndexDto> GenreIndexDtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Genre> genres = await _genreService.GetAll(null, null);
            List<GenreIndexDto> genreIndexDtos = new List<GenreIndexDto>();
            foreach (var about in genres)
            {
                GenreIndexDto genreIndexDto = _mapper.Map<GenreIndexDto>(about);
                genreIndexDtos.Add(genreIndexDto);
            }
            GenreIndexDtos = genreIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete( int id)
        {

            try
            {
                await _genreService.Delete(id);
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
                await _genreService.ToggleDelete(id);
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
