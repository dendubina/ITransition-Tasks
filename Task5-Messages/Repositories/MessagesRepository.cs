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
    public class MessagesRepository : IMessagesRepository
    {
        private readonly AppDbContext _dbContext;

        public MessagesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMessageAsync(Message message)
        {
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetReceivedMessagesAsync(Guid receiverId) =>
            await _dbContext.Messages
                .Where(x => x.RecipientId == receiverId)
                .OrderByDescending(x => x.Date)
                .Include(x => x.Author)
                .Include(x => x.Recipient)
                .ToListAsync();
    }
}
