using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.CountryDTOs;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Data.DAL;
namespace MoviesWebApp.Areas.Admin.Pages.AdminCountry;
public class CreateModel : PageModel
{
    
    private readonly ICountryService _countryService;

    [BindProperty]
    public CountryCreateDto CountryCreateDto { get; set; } = default!;
    public CreateModel(MoviesWebAppContext context , ICountryService countryService)
    {
       
        this._countryService = countryService;
    }
    public IActionResult OnGet()
    {
        return Page();
    }
   
    public async Task<IActionResult> OnPostAsync()
    {
      if(!ModelState.IsValid)
        {
            return Page();
        }
        try
        {
            await _countryService.CreateAsync(CountryCreateDto);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"{ex.Message}");
        }
     
        return RedirectToPage("./Index");
    }
}
