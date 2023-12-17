
using AutoMapper;
using MoviesWebApp.Core.DTO;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Core.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, Movie>()
             .ForMember(dest => dest.ImageURL, opt => opt.Ignore());

            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>()
            .ForMember(dest => dest.VideoURL, opt => opt.Ignore());
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Video, opt => opt.Ignore());



        }
    }
}
