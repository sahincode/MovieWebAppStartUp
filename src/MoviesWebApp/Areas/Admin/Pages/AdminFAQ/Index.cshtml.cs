using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.FAQDTOs;
using MoviesWebApp.Business.DTOs.NewsSlideDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;

using MoviesWebApp.Business.Exceptions.SerialModelExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminFAQ
{
    public class IndexModel : PageModel
    {
        private readonly IFAQService _faqService;
        private readonly IMapper _mapper;

        public IndexModel(IFAQService fAQService, IMapper mapper)
        {
            this._faqService = fAQService;
            this._mapper = mapper;
        }

        public IList<FAQIndexDto> FAQIndexDtos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<FAQ> faqs = await  _faqService.GetAll(null, null);
            List<FAQIndexDto> fAQIndexDtos = new List<FAQIndexDto>();
            foreach(var faq in faqs)
            {
                FAQIndexDto fAQIndexDto = _mapper.Map<FAQIndexDto>(faq);
                fAQIndexDtos.Add(fAQIndexDto);
            }
            FAQIndexDtos = fAQIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            
            try
            {
                await  _faqService.Delete(id);
            }catch(NullIdException ex){
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete( int id)
        {

            try
            {
                await _faqService.ToggleDelete(id);
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
