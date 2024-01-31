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
using MoviesWebApp.Business.DTOs.NewsSlideDTOs;
using MoviesWebApp.Business.DTOs.FAQDTOs;

namespace MoviesWebApp.Areas.Admin.Pages.AdminFAQ
{
    public class CreateModel : PageModel
    {
        
        private readonly  IFAQService _faqService;

        [BindProperty]
        public FAQCreateDto FAQCreateDto { get; set; } = default!;
        public CreateModel( IFAQService fAQService)
        {
           
            this._faqService = fAQService;
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
                await _faqService.CreateAsync(FAQCreateDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }
         
            return RedirectToPage("./Index");
        }
    }
}
