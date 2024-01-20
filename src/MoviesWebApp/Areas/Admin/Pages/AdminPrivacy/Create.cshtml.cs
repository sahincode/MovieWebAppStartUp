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
using MoviesWebApp.Business.DTOs.PrivacyDTOs;

namespace MoviesWebApp.Areas.Admin.Pages.AdminPrivacy
{
    public class CreateModel : PageModel
    {
        
        private readonly IPrivacyService _privacyService;

        [BindProperty]
        public PrivacyCreateDto Privacy { get; set; } = default!;
        public CreateModel(  IPrivacyService privacyService)
        {
            
            this._privacyService = privacyService;
        }
        public IActionResult OnGet()
        {
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
                await _privacyService.CreateAsync(Privacy);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }
         
            return RedirectToPage("./Index");
        }
    }
}
