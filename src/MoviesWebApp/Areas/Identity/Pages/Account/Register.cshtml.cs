// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MoviesWebApp.Business.DTOs.IdentityDTOs;
using MoviesWebApp.Business.Exceptions.IdentityExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;

        public RegisterModel( SignInManager<ApplicationUser> signInManager ,IAccountService accountService)
        {
            
            _signInManager = signInManager;
            this._accountService = accountService;
        }
        [BindProperty]
        public SignUpModelDto SignUpModelDto { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }



        public async Task OnGetAsync(string returnUrl = null)
        {
            
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (!ModelState.IsValid)
            {
               return Page();
            }
            try
            {
                await _accountService.Register(SignUpModelDto);

            }catch(NotSupportedException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (InvalidRegisterAttemptException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }


            return Page();
        }

       
    }
}
