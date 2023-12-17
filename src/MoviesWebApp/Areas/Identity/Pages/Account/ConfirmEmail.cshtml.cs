// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable


using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Identity.Pages.Account
{
    [Area("Identity")]
    public class ConfirmEmailModel : PageModel
    {

        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public bool EmailSent { get; set; }
        public bool EmailVerified { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmailModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
      
    
        public async Task<IActionResult> OnGet (string uid, string token)
        {
            
            

            
           
            var user = await _userManager.FindByIdAsync(uid);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{uid}'.");
            }
            

           
            
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token))
                    
                    
                    
                    ;
                var result = await _userManager.ConfirmEmailAsync(user, token); 
                if (result.Succeeded)
                {
                    EmailVerified = true;
                }
            }
            
            return Page();
        }
    }
}
