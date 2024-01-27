using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.NewsSlideDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.Exceptions;
using MoviesWebApp.Business.Exceptions.SerialModelException;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminNewsSlide
{
    public class IndexModel : PageModel
    {
        private readonly INewsSlideService _newsSlideService;
        private readonly IMapper _mapper;

        public IndexModel(INewsSlideService newsSlideService, IMapper mapper)
        {
            this._newsSlideService = newsSlideService;
            this._mapper = mapper;
        }

        public IList<NewsSlideIndexDto> NewsSlideIndexDtos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<NewsSlide> serials = await  _newsSlideService.GetAll(null, null);
            List<NewsSlideIndexDto> newsSlideIndexDtos = new List<NewsSlideIndexDto>();
            foreach(var serial in serials)
            {
                NewsSlideIndexDto serialIndexDto = _mapper.Map<NewsSlideIndexDto>(serial);
                newsSlideIndexDtos.Add(serialIndexDto);
            }
            NewsSlideIndexDtos = newsSlideIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody]int id)
        {
            
            try
            {
                await  _newsSlideService.Delete(id);
            }catch(NullIdException ex){
                return NotFound(ex.Message);
            }
            catch (SerialNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete( int id)
        {

            try
            {
                await _newsSlideService.ToggleDelete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SerialNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToAction("OnGet");
        }
    }
}
