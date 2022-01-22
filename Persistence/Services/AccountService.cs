using Common.DTOs;
using Common.Middlewares;
using Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Services
{
    public class AccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public AccountService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Login(LoginDto login)
        {
            try
            {
                var usr = await _userManager.FindByEmailAsync(login.Email);
                var result = await _signInManager.CheckPasswordSignInAsync(usr, login.Password, true);

                if (result == Microsoft.AspNetCore.Identity.SignInResult.Success)
                {
                    Guid key = Guid.NewGuid();
                    BlazorCookieLoginMiddleware.Logins[key] = new LoginInfo { Email = login.Email, Password = login.Password };
                    return key.ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
