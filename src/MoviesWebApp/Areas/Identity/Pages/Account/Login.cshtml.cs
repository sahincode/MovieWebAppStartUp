// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.IdentityDTOs;
using MoviesWebApp.Business.Exceptions.IdentityExceptions;
using MoviesWebApp.Business.Services.Interfaces;

namespace MoviesWebApp.Pages.Shared
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            this._accountService = accountService;
        }


        [BindProperty]
        public LoginModelDto LoginModelDto { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return Page();


        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _accountService.Login(LoginModelDto);
            }catch (InavalidLoginAttemptException ex) 
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();
            }

            // If we got this far, something failed, redisplay form
            return RedirectToPage("/Home");
        }
    }
}
