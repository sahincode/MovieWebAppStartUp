using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.Pages.Search
{
    public class SearchResultsModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public PaginatedModelList<MovieIndexDto> MovieIndexDtos { get; set; } = new PaginatedModelList<MovieIndexDto>();
        public SearchResultsModel(IMovieRepository movieRepository ,IMapper mapper)
        {
            this._movieRepository = movieRepository;
            this._mapper = mapper;
        }
        
        public async  Task< IActionResult> OnGet(string p , int paged)
        {
            IQueryable<Movie> query =  _movieRepository.Table.Where(movie => movie.Title.Trim().ToUpper().Contains(p.Trim().ToUpper()) || movie.Description.Trim().ToUpper().Contains(p.Trim().ToUpper())).AsQueryable<Movie>();
           
            PaginatedModelList<Movie> paginatedMovies = PaginatedModelList<Movie>.Create(query, paged, 8);

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
