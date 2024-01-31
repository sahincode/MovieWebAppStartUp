using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using MoviesWebApp.Business.DTOs.IdentityDTOs;
using MoviesWebApp.Business.Exceptions.IdentityExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IEmailService _emailService;

        public AccountService( UserManager<ApplicationUser> userManager ,
            SignInManager<ApplicationUser> signInManager ,
            IConfiguration configuration ,
            IUserStore<ApplicationUser> userStore ,
            IEmailService emailService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
            this._userStore = userStore;
            this._emailService = emailService;
        }
        public async  Task Login(LoginModelDto loginModelDto)
        {
            ApplicationUser applicationUser = null;

            applicationUser =  await _userManager.FindByEmailAsync(loginModelDto.Email);
            if (applicationUser == null)
            {
                throw new InavalidLoginAttemptException(string.Empty, "Email or Password invalid !");
            }
            var result = await  _signInManager.PasswordSignInAsync(applicationUser, loginModelDto.Password, loginModelDto.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new InavalidLoginAttemptException(string.Empty, "Something went wrong!");
            }
          
        }

        public async  Task Register(SignUpModelDto signUpModelDto)
        {
            var user = new ApplicationUser()
            {

                Email = signUpModelDto.Email,
                UserName = signUpModelDto.Username

            };


            var result = await _userManager.CreateAsync(user, signUpModelDto.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));


                if (!string.IsNullOrEmpty(encodedToken))
                {
                    await UserConfirmationEmail(user, encodedToken);
                }
            }
            foreach (var error in result.Errors)
            {
                throw new InvalidRegisterAttemptException(string.Empty, "Something went wrong try again!");
            }
        }
        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
        private async Task UserConfirmationEmail(ApplicationUser user, string token)
        {
            string appdomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions()
            {
                ToEmails = new List<string>()
                {
                    user.Email
                },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}",user.UserName),
                    new KeyValuePair<string, string>("//UserName//",user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",string.Format(appdomain+confirmLink,user.Id,token ,user.Email))
                }
            };

            await _emailService.SendEmailToUserForConfirmation(options);
        }
    }
}
