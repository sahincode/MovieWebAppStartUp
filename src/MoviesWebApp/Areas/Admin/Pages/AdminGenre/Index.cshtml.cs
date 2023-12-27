 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.AboutDTOs;
using MoviesWebApp.Core.DTOs.GenreDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Areas.Admin.Pages.AdminGenre 
{ 
    public class IndexModel : PageModel
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public IndexModel( IGenreService genreService ,IMapper mapper)
        {
            this._genreService = genreService;
            this._mapper = mapper;
        }

        public IList<GenreIndexDto> GenreIndexDtos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Genre> genres = await  _genreService.GetAll(null, null);
            List<GenreIndexDto> genreIndexDtos = new List<GenreIndexDto>();
            foreach(var about in genres)
            {
                GenreIndexDto genreIndexDto = _mapper.Map<GenreIndexDto>(about);
                genreIndexDtos.Add(genreIndexDto);
            }
            GenreIndexDtos = genreIndexDtos;
            return Page();
        }
    }
}
