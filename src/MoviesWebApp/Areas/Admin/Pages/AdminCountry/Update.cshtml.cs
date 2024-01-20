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
using MoviesWebApp.Business.DTOs.CountryDTOs;

namespace MoviesWebApp.Areas.Admin.Pages.AdminCountry
{
    public class UpdateModel : PageModel
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public UpdateModel(ICountryService aboutService, IMapper mapper)
        {
            this._countryService = aboutService;
            this._mapper = mapper;
        }

        [BindProperty]
        public CountryUpdateDto CountryUpdateDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryUpdateDto = await _countryService.Get(a => a.Id == id && a.IsDeleted == false);
            if (countryUpdateDto == null)
            {
                return NotFound();
            }
            CountryUpdateDto = _mapper.Map<CountryUpdateDto>(countryUpdateDto);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid) return Page();

            if (id == null) return NotFound();
            try
            {
                await _countryService.UpdateAsync(id, CountryUpdateDto);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }


    }
}
