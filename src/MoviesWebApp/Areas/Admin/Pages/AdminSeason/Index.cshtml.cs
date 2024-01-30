using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.SeasonDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Exceptions.SeasonModelExceptions;

using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminSeason
{
    public class IndexModel : PageModel
    {
        private readonly ISeasonService _seasonService;
        private readonly IMapper _mapper;

        public IndexModel(ISeasonService seasonService, IMapper mapper)
        {
            this._seasonService = seasonService;
            this._mapper = mapper;
        }

        public IList<SeasonIndexDto> SeasonIndexDtos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Season> seasons = await  _seasonService.GetAll(null, "Serial");
            List<SeasonIndexDto> seasonIndexDtos = new List<SeasonIndexDto>();
            foreach(var serial in seasons)
            {
               SeasonIndexDto seasonIndexDto = _mapper.Map<SeasonIndexDto>(serial);
                seasonIndexDtos.Add(seasonIndexDto);
            }
            SeasonIndexDtos = seasonIndexDtos;
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody]int id)
        {
            
            try
            {
                await  _seasonService.Delete(id);
            }catch(NullIdException ex){
                return NotFound(ex.Message);
            }
            catch (SeasonNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete( int id)
        {

            try
            {
                await _seasonService.ToggleDelete(id);
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
