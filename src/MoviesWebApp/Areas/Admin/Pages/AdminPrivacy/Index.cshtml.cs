 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;
using MoviesWebApp.Business.DTOs.PrivacyDTOs;

namespace MoviesWebApp.Areas.Admin.Pages.AdminPrivacy
{ 
    public class IndexModel : PageModel
    {
        private readonly IPrivacyService _privacyService;
        private readonly IMapper _mapper;

        public IndexModel( IPrivacyService privacyService ,IMapper mapper)
        {
            this._privacyService = privacyService;
            this._mapper = mapper;
        }

        public IList<PrivacyIndexDto> PrivacyIndexDtos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<Privacy> privacies = await  _privacyService.GetAll(null, null);
            List<PrivacyIndexDto> privacyIndexDtos = new List<PrivacyIndexDto>();
            foreach(var privacy in privacies)
            {
                PrivacyIndexDto privacyIndexDto = _mapper.Map<PrivacyIndexDto>(privacy);
                privacyIndexDtos.Add(privacyIndexDto);
            }
            PrivacyIndexDtos = privacyIndexDtos;
            return Page();
        }
    }
}
