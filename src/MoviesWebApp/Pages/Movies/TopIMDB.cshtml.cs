using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.Pages.Movies
{
    public class TopIMDBModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public PaginatedModelList<MovieIndexDto> MovieIndexDtos { get; set; } = new PaginatedModelList<MovieIndexDto>();
        public TopIMDBModel( IMovieRepository movieRepository ,IMapper mapper)
        {
            this._movieRepository = movieRepository;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGet(int id, int paged)
        {
            IQueryable<Movie> query =  _movieRepository.Table.OrderBy(x => x.IMDB);
            PaginatedModelList<Movie> paginatedMovies = PaginatedModelList<Movie>.Create(query, paged, 8);
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
