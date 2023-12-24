using AutoMapper;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieCreateDto, Movie>().ReverseMap();
            CreateMap<MovieDeleteDto, Movie>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();
            CreateMap<MovieIndexDto, Movie>().ReverseMap();


        }
    }
}
