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
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.DTOs.NewsSlideDTOs;

namespace MoviesWebApp.Areas.Admin.Pages.AdminNewsSlide
{
    public class UpdateModel : PageModel
    {
        private readonly INewsSlideService _newsSlideService;
        private readonly IMapper _mapper;

        public UpdateModel(INewsSlideService newsSlideService, IMapper mapper)
        {
            this._newsSlideService = newsSlideService;
            this._mapper = mapper;
        }

        [BindProperty]
        public NewsSlideUpdateDto NewsSlideUpdateDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serial = await _newsSlideService.Get(a => a.Id == id && a.IsDeleted == false);
            if (serial == null)
            {
                return NotFound();
            }
            NewsSlideUpdateDto = _mapper.Map<NewsSlideUpdateDto>(serial);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid) return Page();

            if (id == null) return NotFound();
            try
            {
                await _newsSlideService.UpdateAsync(NewsSlideUpdateDto);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }


    }
}
