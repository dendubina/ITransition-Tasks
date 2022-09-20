using System;
using System.Linq;
using System.Linq.Expressions;
using Task4AuthWebApp.Entities;

namespace Task4AuthWebApp.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetByCondition(Expression<Func<User, bool>> expression, bool trackChanges);

        void DeleteUser(string id);
    }
}
