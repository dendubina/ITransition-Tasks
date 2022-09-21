using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Task4AuthWebApp.Constants;
using Task4AuthWebApp.Entities;
using Task4AuthWebApp.Services.Interfaces;

namespace Task4AuthWebApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<User> SignInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user.Status == UserStatuses.Blocked)
            {
                throw new InvalidOperationException("User is blocked");
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new ArgumentException("Invalid user name or password");
            }

            user.LastSignInDate = DateTime.Now;
            await _userManager.UpdateAsync(user);

            return user;
        }

        public async Task<User> SignUpAsync(string email, string userName, string password)
        {
            var newUser = new User
            {
                UserName = userName,
                Email = email,
                LastSignInDate = DateTime.Now,
                SignUpDate = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description));

                throw new ArgumentException(message);
            }

            return await _userManager.FindByEmailAsync(email);
        }

        public async Task Logout() => await _signInManager.SignOutAsync();
    }
}
