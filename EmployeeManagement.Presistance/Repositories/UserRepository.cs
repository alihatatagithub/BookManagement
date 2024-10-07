using EmployeeManagement.Contracts.Repositories;
using EmployeeManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<User> CheckUserPassword(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, password);
                if (result)
                {
                    return user;
                }
            }
            return null;
        }
        public async Task<string> CreateUser(User user,string password)
        {
            var result = await _userManager.CreateAsync(user,password);
            if (result.Succeeded) return string.Empty;
            string res = string.Empty;
            foreach (var item in result.Errors)
            {
                res += item;
            }
            return res;
        }
        public async Task<string> UpdateUserToken(User user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return string.Empty;
            string res = string.Empty;
            foreach (var item in result.Errors)
            {
                res += item;
            }
            return res;
        }
        public async Task<User> CheckUserToken(string userId,string refreshToken)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (user.RefreshToken == refreshToken && user.RefreshTokenExpireDate <= DateTime.Now) return user;
            }
            return null;

        }

    }
}
