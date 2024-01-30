using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.SettingDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Exceptions.SerialModelExceptions;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminSetting
{
    public class IndexModel : PageModel
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;

        public List<SettingIndexDto> Settings { get; set; } = new List<SettingIndexDto>();

        public IndexModel(ISettingService movieService, IMapper mapper)
        {
            this._settingService = movieService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Setting> settings = await _settingService.GetAll(null, null);
            if (settings is null) return NotFound();
            foreach (Setting setting in settings)
            {
                SettingIndexDto settingIndex = _mapper.Map<SettingIndexDto>(setting);
                Settings.Add(settingIndex);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody] int id)
        {

            try
            {
                await _settingService.Delete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SerialNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        
    }
}
