using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Business.DTOs.SettingDTOs;
using MoviesWebApp.Business.Exceptions.MovieModelExceptions;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminSetting
{
    public class UpdateModel : PageModel
    {
        private readonly ISettingService _settingService;
      

        [BindProperty]
        public SettingUpdateDto Setting { get; set; }
        
        public UpdateModel(ISettingService settingService)
        {
            this._settingService = settingService;
            
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var claims = User.Claims;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _settingService.UpdateAsync(Setting);

            }
            catch(NullEntityException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();

            }
            catch (MovieFileFormatException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}
