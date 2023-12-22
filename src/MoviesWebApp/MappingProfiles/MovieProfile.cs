using AutoMapper;
using MoviesWebApp.Core.Models;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieCreateViewModel, Movie>().ReverseMap();

        }
    }
}
