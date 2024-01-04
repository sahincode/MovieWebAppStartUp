using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;
namespace MoviesWebApp.Areas.Admin.Pages.AdminPrivacy
{
    public class DetailsModel : PageModel
    {
        private readonly IPrivacyService _privacyService;

        public Privacy Privacy { get; set; } = default!;
        public DetailsModel(IPrivacyService privacyService)
        {
            this._privacyService = privacyService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var privacy = await _privacyService.GetById(id);
            if (privacy == null) return NotFound();
            else
            {
                Privacy = privacy;
            }
            return Page();
        }
    }
}
