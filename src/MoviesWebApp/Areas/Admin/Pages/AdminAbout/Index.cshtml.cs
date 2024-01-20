using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.Exceptions;
using MoviesWebApp.Business.Exceptions.AboutModelExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminAbout
{
    public class IndexModel : PageModel
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public IndexModel( IAboutService aboutService ,IMapper mapper)
        {
            this._aboutService = aboutService;
            this._mapper = mapper;
        }

        public IList<AboutIndexDto> LogoPageInfos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<About> abouts = await  _aboutService.GetAll(null, null);
            List<AboutIndexDto> aboutIndexDtos = new List<AboutIndexDto>();
            foreach(var about in abouts)
            {
                AboutIndexDto aboutIndexDto = _mapper.Map<AboutIndexDto>(about);
                aboutIndexDtos.Add(aboutIndexDto);
            }
            LogoPageInfos = aboutIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody]int id)
        {
            
            try
            {
                await  _aboutService.Delete(id);
            }catch(NullIdException ex){
                return NotFound(ex.Message);
            }
            catch (AboutNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete( int id)
        {

            try
            {
                await _aboutService.ToggleDelete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AboutNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToAction("OnGet");
        }
    }
}
