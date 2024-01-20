using AutoMapper;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.CountryDTOs;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Business.DTOs.PrivacyDTOs;
using MoviesWebApp.Business.DTOs.SeasonDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.DTOs.SettingDTOs;
using MoviesWebApp.Core.Models;


namespace MoviesWebApp.Business.MappingProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
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
            //Genre model mapping profile
            CreateMap<GenreCreateDto, Genre>().ReverseMap();
            CreateMap<GenreUpdateDto, Genre>().ReverseMap();
            CreateMap<GenreIndexDto, Genre>().ReverseMap();
            //Setting model mapping profile
            CreateMap<SettingCreateDto, Setting>().ReverseMap();
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
            //Season model mapping profile
            CreateMap<SeasonCreateDto, Season>().ReverseMap();
            CreateMap<SeasonUpdateDto, Season>().ReverseMap();
            CreateMap<SeasonIndexDto, Season>().ReverseMap();
            //Episode model mapping profile
            //CreateMap<EpisodeCreateDto, Serial>().ReverseMap();
            //CreateMap<EpisodeUpdateDto, Serial>().ReverseMap();
            //CreateMap<EpisodeIndexDto, Serial>().ReverseMap();
            //Serial model mapping profile
            CreateMap<CountryCreateDto, Country>().ReverseMap();
            CreateMap<CountryUpdateDto, Country>().ReverseMap();
            CreateMap<CountryIndexDto, Country>().ReverseMap();
        }
    }
}
