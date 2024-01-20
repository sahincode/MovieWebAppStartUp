using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Pages
{

    public class LogoModel : PageModel
    {
        private readonly IAboutService _aboutService;
        private readonly IEmailService _emailServices;


        public LogoModel(
            IAboutService aboutService, IEmailService emailServices)
        {


            this._aboutService = aboutService;
            _emailServices = emailServices;
        }
        //public LogoPageInfo LogoPageInfo { get; set; } = default!;

        public About LogoPageInfos { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {

            LogoPageInfos = _aboutService.GetAll(a => a.IsDeleted == false).Result.FirstOrDefault();
            if (LogoPageInfos == null)
            {
                return NotFound();
            }
            return Page();
        }


    }
}