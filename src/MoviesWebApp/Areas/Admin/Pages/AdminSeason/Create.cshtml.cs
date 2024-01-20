using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.DTOs.SeasonDTOs;

namespace MoviesWebApp.Areas.Admin.Pages.AdminSeason
{
    public class CreateModel : PageModel
    {
        
        private readonly ISeasonService _seasonService;
        private readonly ICountryService _countryService;
        private readonly ISerialService _serialService;

        [BindProperty]
        public SeasonCreateDto SeasonCreateDto { get; set; } = default!;
        public SelectList Countries { get; set; }

        public SelectList Serials { get; set; }
        public CreateModel(MoviesWebAppContext context , 
            ISeasonService seasonService ,
            ICountryService countryService ,ISerialService serialService)
        {
           
            this._seasonService = seasonService;
            this._countryService = countryService;
            this._serialService = serialService;
        }
        public async Task<IActionResult> OnGet()
        {

            var countries = await  _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name","Name");
            }
            var serials = await _serialService.GetAll(null, null);
            if (serials != null)
            {
                Serials = new SelectList(serials, "Id", "Name");
            }
            return Page();
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if(!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _seasonService.CreateAsync(SeasonCreateDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }
         
            return RedirectToPage("./Index");
        }
    }
}
