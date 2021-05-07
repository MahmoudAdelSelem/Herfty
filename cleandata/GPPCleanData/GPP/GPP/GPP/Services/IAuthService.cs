using GPP.Helpers;
using GPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPP.Services
{
    public interface IAuthService
    {
       
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> RegisterUserAsync(RegisterUserModel model);
        Task<AuthModel> GetTokenAsync( TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
