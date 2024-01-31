using AutoMapper;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.CountryDTOs;
using MoviesWebApp.Business.DTOs.EpisodeDTOs;
using MoviesWebApp.Business.DTOs.FAQDTOs;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Business.DTOs.NewsSlideDTOs;
using MoviesWebApp.Business.DTOs.PrivacyDTOs;
using MoviesWebApp.Business.DTOs.SeasonDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.DTOs.SettingDTOs;
using MoviesWebApp.Business.DTOs.SlideDTOs;
using MoviesWebApp.Core.Models;


namespace MoviesWebApp.Business.MappingProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //movie model mapping profile
            CreateMap<MovieCreateDto, Movie>().ReverseMap();
      
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();
            CreateMap<MovieIndexDto, Movie>().ReverseMap();
            CreateMap<HeaderSlideDto, Movie>().ReverseMap();

            //About model mapping profile
            CreateMap<AboutCreateDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();
            CreateMap<AboutIndexDto, About>().ReverseMap();
            //Genre model mapping profile
            CreateMap<GenreCreateDto, Genre>().ReverseMap();
            CreateMap<GenreUpdateDto, Genre>().ReverseMap();
            CreateMap<GenreIndexDto, Genre>().ReverseMap();
            //Setting model mapping profile
            CreateMap<SettingUpdateDto, Setting>().ReverseMap();
            CreateMap<SettingIndexDto, Setting>().ReverseMap();
            CreateMap<SettingLayoutDto, Setting>().ReverseMap();
            //Privacy model mapping profile
            CreateMap<PrivacyCreateDto, Privacy>().ReverseMap();
            CreateMap<PrivacyUpdateDto, Privacy>().ReverseMap();
            CreateMap<PrivacyIndexDto, Privacy>().ReverseMap();
            //Serial model mapping profile
            CreateMap<SerialCreateDto, Serial>().ReverseMap();
            CreateMap<SerialUpdateDto, Serial>().ReverseMap();
            CreateMap<SerialIndexDto, Serial>().ReverseMap();
            CreateMap<SerialUserIndexDto, Serial>().ReverseMap();

            //Season model mapping profile
            CreateMap<SeasonCreateDto, Season>().ReverseMap();
            CreateMap<SeasonUpdateDto, Season>().ReverseMap();
            CreateMap<SeasonIndexDto, Season>().ReverseMap();
            //Episode model mapping profile
            CreateMap<EpisodeCreateDto, Episode>().ReverseMap();
            CreateMap<EpisodeUpdateDto, Episode>().ReverseMap();
            CreateMap<EpisodeIndexDto, Episode>().ReverseMap();
            //Serial model mapping profile
            CreateMap<CountryCreateDto, Country>().ReverseMap();
            CreateMap<CountryUpdateDto, Country>().ReverseMap();
            CreateMap<CountryIndexDto, Country>().ReverseMap();
            //NewsSlide model mappping profile
            CreateMap<NewsSlideCreateDto, NewsSlide>().ReverseMap();
            CreateMap<NewsSlideUpdateDto, NewsSlide>().ReverseMap();
            CreateMap<NewsSlideIndexDto, NewsSlide>().ReverseMap();
            CreateMap<NewsSlideIndexDto, NewsSlide>().ReverseMap();
            //FAQ model mappping profile
            CreateMap<FAQCreateDto, FAQ>().ReverseMap();
            CreateMap<FAQUpdateDto, FAQ>().ReverseMap();
            CreateMap<FAQIndexDto, FAQ>().ReverseMap();
            CreateMap<FAQLayoutDto, FAQ>().ReverseMap();
        }
    }
}
