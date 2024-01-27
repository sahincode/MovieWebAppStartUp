using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.SlideDTOs;
using MoviesWebApp.Business.DTOs.SubscriberDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;

namespace MoviesWebApp.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public List<HeaderSlideDto> HeaderSlides { get; set; } = new List<HeaderSlideDto>();
        public HomeModel(ISubscriberRepository subscriberRepository,
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            this._subscriberRepository = subscriberRepository;
            this._movieRepository = movieRepository;
            this._mapper = mapper;
        }
        public IActionResult OnGet()
        {
            var movies = _movieRepository.Table.OrderBy(x => x.CreationTime).Take(10).ToList();
            if (movies.Count != 0)
            {
                foreach (var movie in movies)
                {
                    HeaderSlideDto headerSlideDto = _mapper.Map<HeaderSlideDto>(movie);
                    HeaderSlides.Add(headerSlideDto);
                }

            }
            return Page();
        }
        public async Task<IActionResult> OnPostSubscribe(string email)
        {

            Subscriber subscribe = new Subscriber()
            {
                Email = email
            };
            await _subscriberRepository.Table.AddAsync(subscribe);
            var result = await _subscriberRepository.CommitChange();
            if (result >= 1)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }

        }
    }
}
