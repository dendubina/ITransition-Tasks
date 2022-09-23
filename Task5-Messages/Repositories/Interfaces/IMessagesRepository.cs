using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task5_Messages.EF.Entities;

namespace Task5_Messages.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        Task<IEnumerable<Message>> GetReceivedMessagesAsync(Guid receiverId);

        Task AddMessageAsync(Message message);
    }
}
