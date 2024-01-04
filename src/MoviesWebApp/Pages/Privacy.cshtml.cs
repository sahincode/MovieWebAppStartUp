using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.PrivacyDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IPrivacyService _privacyService;
        private readonly IMapper _mapper;

        public PrivacyIndexDto PrivacyIndexDto { get; set; }
        public PrivacyModel(IPrivacyService privacyService, IMapper mapper)
        {
            this._privacyService = privacyService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                Privacy privacy = await _privacyService.Get(p => p.IsDeleted == false);
                PrivacyIndexDto = _mapper.Map<PrivacyIndexDto>(privacy);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }

            return Page();

        }
    }
}
