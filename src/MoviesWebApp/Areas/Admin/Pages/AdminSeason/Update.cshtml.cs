using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.DTOs.SeasonDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;

namespace MoviesWebApp.Areas.Admin.Pages.AdminSeason
{
    public class UpdateModel : PageModel
    {
        private readonly ISeasonService _seasonService;
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;
        private readonly ISerialService _serialService;

        public UpdateModel(ISeasonService seasonService, IMapper mapper,
            ICountryService countryService, ISerialService serialService)
        {
            this._seasonService = seasonService;
            this._mapper = mapper;
            this._countryService = countryService;
            this._serialService = serialService;
        }

        [BindProperty]
        public SeasonUpdateDto SeasonUpdateDto { get; set; } = default!;
        public SelectList Countries { get; set; }

        public SelectList Serials { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            var serials = await _serialService.GetAll(null, null);
            if (serials != null)
            {
                Serials = new SelectList(serials, "Id", "Name");
            }

            var serial = await _seasonService.Get(a => a.Id == id && a.IsDeleted == false);
            if (serial == null)
            {
                return NotFound();
            }
            SeasonUpdateDto = _mapper.Map<SeasonUpdateDto>(serial);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(SeasonUpdateDto seasonUpdateDto)
        {
            if (!ModelState.IsValid) return Page();


            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            var serials = await _serialService.GetAll(null, null);
            if (serials != null)
            {
                Serials = new SelectList(serials, "Id", "Name");
            }
           
           
            try
            {
                await _seasonService.UpdateAsync(seasonUpdateDto);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }


    }
}
