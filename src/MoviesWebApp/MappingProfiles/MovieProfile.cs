using AutoMapper;
using MoviesWebApp.Core.DTOs.AboutDTOs;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            //movie model mapping profile
            CreateMap<MovieCreateDto, Movie>().ReverseMap();
            CreateMap<MovieDeleteDto, Movie>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();
            CreateMap<MovieIndexDto, Movie>().ReverseMap();
            //About model mapping profile
            CreateMap<AboutCreateDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();
            CreateMap<AboutIndexDto, About>().ReverseMap();


        }
    }
}
