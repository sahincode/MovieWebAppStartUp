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

namespace MoviesWebApp.Areas.Admin.Pages.AdminAbout
{
    public class CreateModel : PageModel
    {
        
        private readonly IAboutService _aboutService;

        [BindProperty]
        public AboutCreateDto LogoPageInfo { get; set; } = default!;
        public CreateModel(MoviesWebAppContext context , IAboutService aboutService)
        {
           
            this._aboutService = aboutService;
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
                await _aboutService.CreateAsync(LogoPageInfo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }
         
            return RedirectToPage("./Index");
        }
    }
}
