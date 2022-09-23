using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task5_Messages.EF;
using Task5_Messages.EF.Entities;
using Task5_Messages.Repositories.Interfaces;

namespace Task5_Messages.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(string name)
        {
            _dbContext.Users.Add(new User { Name = name });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindByName(string substring) =>
            await _dbContext.Users.Where(x => x.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
    }
}
