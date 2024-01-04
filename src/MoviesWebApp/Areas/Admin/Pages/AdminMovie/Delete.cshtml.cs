using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public DeleteModel(IMovieService service ,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [BindProperty]
        public MovieDeleteDto Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var movie =  await _service.GetById(id);
            if (movie == null) return NotFound();
            Movie = _mapper.Map<MovieDeleteDto>(movie);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var movie = await _service.GetById(id);
            if (movie == null) return NotFound();
            Movie = _mapper.Map<MovieDeleteDto>(movie);
             await _service.Delete(Movie);
            return Page();
        }
    }
}
