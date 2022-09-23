using System.Collections.Generic;
using System.Threading.Tasks;
using Task5_Messages.EF.Entities;

namespace Task5_Messages.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(string name);

        Task<IEnumerable<User>> FindByNameAsync(string substring);

        Task<User> GetByNameAsync(string name);
    }
}
