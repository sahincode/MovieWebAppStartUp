using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.InternalHelperServices;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMapper mapper,
            IWebHostEnvironment environment,
            IMovieRepository movieRepository)
        {
            this._mapper = mapper;
            _environment = environment;
            _movieRepository = movieRepository;
        }

        public string imagePassPath = "assets/uploads/movies/images";
        public string videoPassPath = "assets/uploads/movies/videos";


        public async Task CreateAsync(MovieCreateDto entity)
        {
            //check file type of the entity files
            if (entity.Image.ContentType != "image/png" && entity.Image.ContentType != "image/jpeg")
                throw new MovieFileFormatException("Image", "please add png or jpeg file");
            if (entity.Video.ContentType != "video/mp4" && entity.Video.ContentType != "video/mpeg")
                throw new MovieFileFormatException("Video", "please add mp4  or mpeg file");
            string rootPath = _environment.WebRootPath;
            var movie = _mapper.Map<Movie>(entity);
            movie.ImageURL = await FileHelper.SaveImage(rootPath, imagePassPath, entity.Image);
            movie.VideoURL = await FileHelper.SaveImage(rootPath, videoPassPath, entity.Video);
            await _movieRepository.CreateAsync(movie);
            await _movieRepository.CommitChange();
        }

        public async Task Delete(int id)
        {
            string rootPath = _environment.WebRootPath;
            var movie = await _movieRepository.Get(m => m.Id == id);
            if (movie == null) throw new NullEntityException("", $"The movie with the ID equal to" +
               $" {id} was not found in the database.");
            string imageFullPath = Path.Combine(rootPath, imagePassPath, movie.ImageURL);
            string videoFullPath = Path.Combine(rootPath, imagePassPath, movie.VideoURL);
            System.IO.File.Delete(imageFullPath);
            System.IO.File.Delete(videoFullPath);
            _movieRepository.Delete(movie);
            await _movieRepository.CommitChange();
        }

        public async Task<Movie> Get(Expression<Func<Movie, bool>>? predicate, params string[]? includes)
        {
            return await _movieRepository.Get(predicate, includes);
        }

        public async Task<IEnumerable<Movie>> GetAll(Expression<Func<Movie, bool>>? predicate, params string[]? includes)
        {
            return await _movieRepository.GetAll(predicate, includes);

        }

        public async Task<Movie> GetById(int id)
        {

            return await _movieRepository.Get(m => m.Id == id) is not null ?
               await _movieRepository.Get(m => m.Id == id) :
               throw new EntityNotFoundException($"The movie with the ID equal to" +
               $" {id} was not found in the database.");
        }
        public async Task SoftDelete(int id)
        {
            var movie = await _movieRepository.Get(m => m.Id == id);
            if (movie == null) throw new NullEntityException("", $"The movie with the ID equal to" +
               $" {id} was not found in the database.");
            movie.IsDeleted = !movie.IsDeleted;
            await _movieRepository.CommitChange();

        }


        public async Task UpdateAsync( MovieUpdateDto entity)
        {
            string rootPath = _environment.WebRootPath;


            var updatedMovie = await _movieRepository.Get(m => m.Id == entity.Id);

            updatedMovie = _mapper.Map(entity, updatedMovie);
            if (entity.Image != null)
            {
                if (entity.Image.ContentType != "image/png" && entity.Image.ContentType != "image/jpeg")
                    throw new MovieFileFormatException("Image", "please add png or jpeg file");
                updatedMovie.ImageURL = await FileHelper.SaveImage(rootPath, imagePassPath, entity.Image);
            }

            if (entity.Video != null)
            {
                if (entity.Video.ContentType != "video/mp4" && entity.Video.ContentType != "video/mpeg")
                    throw new MovieFileFormatException("Video", "please add mp4  or mpeg file");
                updatedMovie.VideoURL = await FileHelper.SaveImage(rootPath, videoPassPath, entity.Video);
            }
            await _movieRepository.CommitChange();
        }


    }
}

