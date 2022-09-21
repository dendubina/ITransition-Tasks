using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Task4AuthWebApp.Constants;
using Task4AuthWebApp.Entities;

namespace Task4AuthWebApp.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> FindAll();

        IQueryable<User> GetByCondition(Expression<Func<User, bool>> expression, bool trackChanges);

        Task DeleteUser(string id);

        Task ChangeStatus(string id, UserStatuses status);
    }
}
