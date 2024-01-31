using MoviesWebApp.Business.DTOs.IdentityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public  interface IAccountService
    {
        public Task Login(LoginModelDto loginModelDto);
        public Task Register(SignUpModelDto signUpModelDto);

    }
}
