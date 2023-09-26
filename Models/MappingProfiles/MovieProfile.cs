using AutoMapper;
using MoviesWebApp.Models.DTO;

namespace MoviesWebApp.Models.MappingProfiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile() 
        {
            CreateMap<moviemodel, Movies>()
             .ForMember(dest => dest.ImageURL, opt => opt.Ignore());

            CreateMap<Movies,moviemodel>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<moviemodel, Movies>()
            .ForMember(dest => dest.VideoURL, opt => opt.Ignore());
            CreateMap<Movies, moviemodel>()
                .ForMember(dest => dest.Video, opt => opt.Ignore());



        }
    }
}
