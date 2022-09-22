using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task4AuthWebApp.Constants;
using Task4AuthWebApp.Entities;
using Task4AuthWebApp.Services.Interfaces;

namespace Task4AuthWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IQueryable<User> FindAll()
            => _userManager.Users;

        public IQueryable<User> GetByCondition(Expression<Func<User, bool>> expression, bool trackChanges)
        {
            var query = _userManager.Users.Where(expression);

            return trackChanges ? query : query.AsNoTracking();
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new ArgumentException($"User with id {id} not found");
            }

            await _userManager.DeleteAsync(user);
        }

        public async Task ChangeStatus(string id, UserStatuses status)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new ArgumentException($"User with id {id} not found");
            }

            user.Status = status;
            await _userManager.UpdateAsync(user);
        }
    }
}
