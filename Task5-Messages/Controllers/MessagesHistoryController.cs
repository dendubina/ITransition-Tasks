using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task5_Messages.Repositories.Interfaces;

namespace Task5_Messages.Controllers
{
    public class MessagesHistoryController : Controller
    {
        private readonly IMessagesRepository _messagesRepository;

        public MessagesHistoryController(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageHistoryBlock(Guid userId)
        {
            var messages = await _messagesRepository.GetReceivedMessagesAsync(userId);

            return PartialView(messages);
        }

    }
}
