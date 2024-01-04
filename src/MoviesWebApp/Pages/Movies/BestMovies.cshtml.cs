using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.Pages.Movies
{
    public class BestMoviesModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        [BindProperty]
        public PaginatedModelList<MovieIndexDto> MovieIndexDtos
        { get; set; } = new PaginatedModelList<MovieIndexDto>();
        public BestMoviesModel(IMovieService movieService, IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGet(int paged)
        {
            IQueryable<Movie> query = _movieService.GetAll(m => m.IMDB >= 7, "MovieGenres").Result.AsQueryable();
            PaginatedModelList<Movie> paginatedMovies = PaginatedModelList<Movie>.Create(query, paged, 50);

            if (paginatedMovies != null)
            {
                MovieIndexDtos.CurrentPage = paginatedMovies.CurrentPage;
                MovieIndexDtos.PageCount = paginatedMovies.PageCount;
                MovieIndexDtos.HasNext = paginatedMovies.HasNext;
                MovieIndexDtos.HasPrev = paginatedMovies.HasPrev;
                foreach (var paginatedMovie in paginatedMovies)
                {
                    MovieIndexDto indexMovieModel = _mapper.Map<MovieIndexDto>(paginatedMovie);
                    MovieIndexDtos.Add(indexMovieModel);

                }
            }
            return Page();
        }
    }
}
