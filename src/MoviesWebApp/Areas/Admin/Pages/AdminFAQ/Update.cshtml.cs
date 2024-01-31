using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.FAQDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;

namespace MoviesWebApp.Areas.Admin.Pages.AdminFAQ
{
    public class UpdateModel : PageModel
    {
        private readonly IFAQService _faqService;
        private readonly IMapper _mapper;

        public UpdateModel(IFAQService fAQService, IMapper mapper)
        {
            this._faqService = fAQService;
            this._mapper = mapper;
        }

        [BindProperty]
        public FAQUpdateDto FAQUpdateDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _faqService.Get(a => a.Id == id && a.IsDeleted == false);
            if (faq == null)
            {
                return NotFound();
            }
            FAQUpdateDto = _mapper.Map<FAQUpdateDto>(faq);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid) return Page();

            if (id == null) return NotFound();
            try
            {
                await _faqService.UpdateAsync(FAQUpdateDto);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }


    }
}
