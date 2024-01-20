using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.CountryDTOs;
using MoviesWebApp.Business.Exceptions;
using MoviesWebApp.Business.Exceptions.AboutModelExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminCountry
{
    public class IndexModel : PageModel
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public IndexModel( ICountryService countryService, IMapper mapper)
        {
            this._countryService = countryService;
            this._mapper = mapper;
        }

        public IList<CountryIndexDto> CountryIndexDtos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Country> countries = await  _countryService.GetAll(null, null);
            List<CountryIndexDto> aboutIndexDtos = new List<CountryIndexDto>();
            foreach(var country in countries)
            {
                CountryIndexDto aboutIndexDto = _mapper.Map<CountryIndexDto>(country);
                aboutIndexDtos.Add(aboutIndexDto);
            }
            CountryIndexDtos = aboutIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody]int id)
        {
            
            try
            {
                await  _countryService.Delete(id);
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
                await _countryService.ToggleDelete(id);
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
