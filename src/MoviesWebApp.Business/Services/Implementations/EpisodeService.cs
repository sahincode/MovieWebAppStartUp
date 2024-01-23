using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using MoviesWebApp.Business.DTOs.EpisodeDTOs;
using MoviesWebApp.Business.Exceptions.EpisodeModelException;
using MoviesWebApp.Business.Exceptions.GenreModelExceptions;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.InternalHelperServices;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace EpisodesWebApp.Business.Services.Implementations
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IGenreService _genreService;
        private readonly IEpisodeGenreRepository _episodeGenreRepository;

        public EpisodeService(IMapper mapper,
            IWebHostEnvironment environment,
            IEpisodeRepository episodeRepository,
            IGenreService genreService,
            IEpisodeGenreRepository episodeGenreRepository)
        {
            this._mapper = mapper;
            _environment = environment;
            _episodeRepository = episodeRepository;
            this._genreService = genreService;
            this._episodeGenreRepository = episodeGenreRepository;
        }

        public string imagePassPath = "assets/uploads/episodes/images";
        public string videoPassPath = "assets/uploads/episodes/videos";


        public async Task CreateAsync(EpisodeCreateDto entity)
        {

            var genres = await _genreService.GetAll(g => g.IsDeleted == false);
            foreach (var genreId in entity.GenreIds)
            {
                if (!genres.Any(g => g.Id == genreId))
                {
                    throw new NotExistGenreException("GenreIds", "Some genre does not exist");
                }
            }
            var episode = _mapper.Map<Episode>(entity);
            foreach (var genreId in entity.GenreIds)
            {
                EpisodeGenre episodeGenre = new EpisodeGenre()
                {
                    Episode = episode,
                    GenreId = genreId
                };
                _episodeGenreRepository.Table.Add(episodeGenre);
            }


            if (entity.Image.ContentType != "image/png" && entity.Image.ContentType != "image/jpeg")
                throw new EpisodeFileFormatException("Image", "please add png or jpeg file");
            if (entity.Video.ContentType != "video/mp4" && entity.Video.ContentType != "video/mpeg")
                throw new EpisodeFileFormatException("Video", "please add mp4  or mpeg file");
            string rootPath = _environment.WebRootPath;

            episode.ImageURL = await FileHelper.SaveImage(rootPath, imagePassPath, entity.Image);
            episode.VideoURL = await FileHelper.SaveImage(rootPath, videoPassPath, entity.Video);
            await _episodeRepository.CreateAsync(episode);
            await _episodeRepository.CommitChange();
        }



        public async Task<Episode> Get(Expression<Func<Episode, bool>>? predicate, params string[]? includes)
        {
            return await _episodeRepository.Get(predicate, includes);
        }

        public async Task<IEnumerable<Episode>> GetAll(Expression<Func<Episode, bool>>? predicate, params string[]? includes)
        {
            return await _episodeRepository.GetAll(predicate, includes);

        }

        public async Task<Episode> GetById(int? id)
        {

            return await _episodeRepository.Get(m => m.Id == id) is not null ?
               await _episodeRepository.Get(m => m.Id == id) :
               throw new EntityNotFoundException($"The Episode with the ID equal to" +
               $" {id} was not found in the database.");
        }
        public async Task ToggleDelete(int id)
        {
            var Episode = await _episodeRepository.Get(m => m.Id == id);
            if (Episode == null) throw new NullEntityException("", $"The Episode with the ID equal to" +
               $" {id} was not found in the database.");
            Episode.IsDeleted = !Episode.IsDeleted;
            await _episodeRepository.CommitChange();

        }


        public async Task UpdateAsync(EpisodeUpdateDto entity)
        {
            string rootPath = _environment.WebRootPath;
            var genres = await _genreService.GetAll(g => g.IsDeleted == false);
            foreach (var genreId in entity.GenreIds)
            {
                if (genres.Any(g => g.Id != genreId))
                {
                    throw new NotExistGenreException("GenreIds", "Some genre does not exist");
                }
            }
            var updatedEpisode = await _episodeRepository.Get(m => m.Id == entity.Id);
            var result = updatedEpisode.EpisodeGenres.RemoveAll(g => entity.GenreIds.Any(gId => gId != g.Id));
            var genreIds = entity.GenreIds.FindAll(gId => updatedEpisode.EpisodeGenres.Any(g => g.GenreId != g.Id));
            foreach (var genreId in genreIds)
            {
                EpisodeGenre episodeGenre = new EpisodeGenre()
                {
                    Episode = updatedEpisode,
                    GenreId = genreId
                };
                updatedEpisode.EpisodeGenres.Add(episodeGenre);
            }
            updatedEpisode = _mapper.Map(entity, updatedEpisode);
            if (entity.Image != null)
            {
                if (entity.Image.ContentType != "image/png" && entity.Image.ContentType != "image/jpeg")
                    throw new EpisodeFileFormatException("Image", "please add png or jpeg file");
                updatedEpisode.ImageURL = await FileHelper.SaveImage(rootPath, imagePassPath, entity.Image);
            }

            if (entity.Video != null)
            {
                if (entity.Video.ContentType != "video/mp4" && entity.Video.ContentType != "video/mpeg")
                    throw new EpisodeFileFormatException("Video", "please add mp4  or mpeg file");
                updatedEpisode.VideoURL = await FileHelper.SaveImage(rootPath, videoPassPath, entity.Video);
            }
            await _episodeRepository.CommitChange();
        }



        public async Task Delete(int id)
        {
            string rootPath = _environment.WebRootPath;
            var movie = await _episodeRepository.Get(m => m.Id == id);
            if (movie == null) throw new NullEntityException("", $"The movie with the ID equal to" +
               $" {id} was not found in the database.");
            string imageFullPath = Path.Combine(rootPath, imagePassPath, movie.ImageURL);
            string videoFullPath = Path.Combine(rootPath, imagePassPath, movie.VideoURL);
            System.IO.File.Delete(imageFullPath);
            System.IO.File.Delete(videoFullPath);
            _episodeRepository.Delete(movie);
            await _episodeRepository.CommitChange();
        }



    }
}
