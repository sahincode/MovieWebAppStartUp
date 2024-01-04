using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Areas.Admin.Pages.AdminAbout
{
    public class UpdateModel : PageModel
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public UpdateModel(IAboutService aboutService, IMapper mapper)
        {
            this._aboutService = aboutService;
            this._mapper = mapper;
        }

        [BindProperty]
        public AboutUpdateDto LogoPageInfos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logoPageInfos = await _aboutService.Get(a => a.Id == id && a.IsDeleted == false);
            if (logoPageInfos == null)
            {
                return NotFound();
            }
            LogoPageInfos = _mapper.Map<AboutUpdateDto>(logoPageInfos);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid) return Page();

            if (id == null) return NotFound();
            try
            {
                await _aboutService.UpdateAsync(id, LogoPageInfos);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }


    }
}
