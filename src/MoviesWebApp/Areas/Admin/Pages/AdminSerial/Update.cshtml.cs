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

namespace MoviesWebApp.Areas.Admin.Pages.AdminSerial
{
    public class UpdateModel : PageModel
    {
        private readonly ISerialService _serialService;
        private readonly IMapper _mapper;

        public UpdateModel(ISerialService serialService, IMapper mapper)
        {
            this._serialService = serialService;
            this._mapper = mapper;
        }

        [BindProperty]
        public SerialUpdateDto SerialUpdateDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serial = await _serialService.Get(a => a.Id == id && a.IsDeleted == false);
            if (serial == null)
            {
                return NotFound();
            }
             SerialUpdateDto = _mapper.Map<SerialUpdateDto>(serial);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid) return Page();

            if (id == null) return NotFound();
            try
            {
                await _serialService.UpdateAsync(id, SerialUpdateDto);
            }
            catch (EntityNotFoundException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
            }

            return RedirectToPage("./Index");
        }


    }
}
