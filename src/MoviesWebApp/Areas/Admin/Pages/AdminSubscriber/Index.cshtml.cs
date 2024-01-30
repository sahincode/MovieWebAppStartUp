using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.SubscriberDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminSubscriber
{
    public class IndexModel : PageModel
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;

        public IndexModel( ISubscriberService subscriberService ,IMapper mapper)
        {
            this._subscriberService = subscriberService;
            this._mapper = mapper;
        }

        public IList<SubscriberIndexDto> Subscribers { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Subscriber> abouts = await  _subscriberService.GetAll(null, null);
            List<SubscriberIndexDto> subscriberIndexDtos = new List<SubscriberIndexDto>();
            foreach(var about in abouts)
            {
                SubscriberIndexDto subscriberIndexDto = _mapper.Map<SubscriberIndexDto>(about);
                subscriberIndexDtos.Add(subscriberIndexDto);
            }
            Subscribers = subscriberIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody] int id)
        {

            try
            {
                await _subscriberService.Delete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete(int id)
        {

            try
            {
                await _subscriberService.ToggleDelete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToAction("OnGet");
        }
    }
}
