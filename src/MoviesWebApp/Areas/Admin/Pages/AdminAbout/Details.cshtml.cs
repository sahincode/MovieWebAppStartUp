using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.AboutDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;
namespace MoviesWebApp.Areas.Admin.Pages.AdminAbout
{
    public class DetailsModel : PageModel
    {
        private readonly IAboutService _aboutService;

        public About  LogoPageInfo { get; set; } = default!;
        public DetailsModel( IAboutService aboutService)
        {
            this._aboutService = aboutService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var about = await _aboutService.GetById(id);
            if (about == null) return NotFound();
            else
            {
                LogoPageInfo = about;
            }
            return Page();
        }
    }
}
