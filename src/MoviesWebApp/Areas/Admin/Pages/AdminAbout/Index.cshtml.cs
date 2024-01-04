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


namespace MoviesWebApp.Areas.Admin.Pages.AdminAbout
{ 
    public class IndexModel : PageModel
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public IndexModel( IAboutService aboutService ,IMapper mapper)
        {
            this._aboutService = aboutService;
            this._mapper = mapper;
        }

        public IList<AboutIndexDto> LogoPageInfos { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            IEnumerable<About> abouts = await  _aboutService.GetAll(null, null);
            List<AboutIndexDto> aboutIndexDtos = new List<AboutIndexDto>();
            foreach(var about in abouts)
            {
                AboutIndexDto aboutIndexDto = _mapper.Map<AboutIndexDto>(about);
                aboutIndexDtos.Add(aboutIndexDto);
            }
            LogoPageInfos = aboutIndexDtos;
            return Page();
        }
    }
}
