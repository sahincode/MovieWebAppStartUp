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
using MoviesWebApp.Business.DTOs.PrivacyDTOs;

namespace MoviesWebApp.Areas.Admin.Pages.AdminPrivacy
{
    public class UpdateModel : PageModel
    {
        private readonly IPrivacyService _privacyService;
        private readonly IMapper _mapper;

        public UpdateModel(IPrivacyService privacyService, IMapper mapper)
        {
            this._privacyService = privacyService;
            this._mapper = mapper;
        }

        [BindProperty]
        public PrivacyUpdateDto PrivacyUpdateDtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privacy = await _privacyService.Get(a => a.Id == id && a.IsDeleted == false);
            if (privacy == null)
            {
                return NotFound();
            }
            PrivacyUpdateDtos = _mapper.Map<PrivacyUpdateDto>(privacy);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid) return Page();

            if (id == null) return NotFound();
            try
            {
                await _privacyService.UpdateAsync(id, PrivacyUpdateDtos);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }


    }
}
