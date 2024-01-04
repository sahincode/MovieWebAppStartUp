using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.SubscriberDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;

namespace MoviesWebApp.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ISubscriberRepository _subscriberRepository;
        public HomeModel(ISubscriberRepository subscriberRepository)
        {
            this._subscriberRepository = subscriberRepository;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostSubscribe(string email)
        {
           
            Subscriber subscribe = new Subscriber()
            {
                Email=email
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
