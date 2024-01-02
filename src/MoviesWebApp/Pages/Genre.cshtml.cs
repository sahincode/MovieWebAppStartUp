using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MoviesWebApp.Pages
{
    public class GenreModel : PageModel
    {

        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public PaginatedModelList<MovieIndexDto> MovieIndexDtos { get; set; } = new PaginatedModelList<MovieIndexDto>();
        public GenreModel(IMovieService movieService, IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGet(int id , int paged )
        {
            IEnumerable<Movie> query = await _movieService.
                GetAll(m => m.MovieGenres.Any(mg => mg.GenreId == id), "MovieGenres");
            PaginatedModelList<Movie> paginatedMovies = PaginatedModelList<Movie>.Create(query.AsQueryable(), paged, 8);
            MovieIndexDtos.CurrentPage = paginatedMovies.CurrentPage;
            MovieIndexDtos.PageCount = paginatedMovies.PageCount;
            MovieIndexDtos.HasNext = paginatedMovies.HasNext;
            MovieIndexDtos.HasPrev = paginatedMovies.HasPrev;
            foreach (var movie in paginatedMovies)
            {
                MovieIndexDto movieIndexDto = _mapper.Map<MovieIndexDto>(movie);
                MovieIndexDtos.Add(movieIndexDto);
            }
            return Page();
        }
    }
}
