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

namespace MoviesWebApp.Areas.Admin.Pages.AdminSerial
{
    public class CreateModel : PageModel
    {
        
        private readonly ISerialService _serialService;

        [BindProperty]
        public SerialCreateDto SerialCreateDto { get; set; } = default!;
        public CreateModel(MoviesWebAppContext context , ISerialService serialService)
        {
           
            this._serialService = serialService;
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
                await _serialService.CreateAsync(SerialCreateDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }
         
            return RedirectToPage("./Index");
        }
    }
}
