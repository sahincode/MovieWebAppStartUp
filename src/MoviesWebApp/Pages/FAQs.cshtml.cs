using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.FAQDTOs;
using MoviesWebApp.Business.Services.Interfaces;

namespace MoviesWebApp.Pages
{
    public class FAQsModel : PageModel
    {
        private readonly IFAQService _fAQService;
        private readonly IMapper _mapper;
        [BindProperty]
        public List<FAQLayoutDto> FAQLayoutDtos { get; set; } = new List<FAQLayoutDto>();
        public FAQsModel(IFAQService fAQService ,IMapper mapper)
        {
            this._fAQService = fAQService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGet()
        {
            var faqs = await  _fAQService.GetAll(f => f.IsDeleted == false);
            foreach(var faq in faqs)
            {
                FAQLayoutDto fAQLayoutDto = _mapper.Map<FAQLayoutDto>(faq);
                FAQLayoutDtos.Add(fAQLayoutDto);
            }
            return Page();
        }
    }
}
