using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.Pages.Movies
{
    public class MovieModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public PaginatedModelList<MovieIndexDto> MovieIndexDtos { get; set; } = new PaginatedModelList<MovieIndexDto>();
        
        public MovieModel(IMovieRepository movieRepository ,IMapper mapper)
        {
            this._movieRepository = movieRepository;
            this._mapper = mapper;
        }
        public async  Task<IActionResult> OnGet( int paged)
        {
            
            IQueryable<Movie> query = _movieRepository.Table.AsQueryable<Movie>();
            PaginatedModelList<Movie> paginatedMovies = PaginatedModelList<Movie>.Create(query, paged, 5);
               
            if (paginatedMovies != null)
            {
                MovieIndexDtos.CurrentPage = paginatedMovies.CurrentPage;
                MovieIndexDtos.PageCount = paginatedMovies.PageCount;
                MovieIndexDtos.HasNext = paginatedMovies.HasNext;
                MovieIndexDtos.HasPrev = paginatedMovies.HasPrev;


                foreach (var paginatedMovie in paginatedMovies)
                {
                    MovieIndexDto indexMovieModel =_mapper.Map<MovieIndexDto>(paginatedMovie);
                    MovieIndexDtos.Add(indexMovieModel);

                }

                
            }
            return Page();
        }
    }
}
