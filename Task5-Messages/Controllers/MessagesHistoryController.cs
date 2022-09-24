using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Task5_Messages.Models;
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
        public async Task<IActionResult> Messages(Guid userId)
        {
            var messages = await _messagesRepository.GetReceivedMessagesAsync(userId);

            return Json(messages);
        }

        [HttpPost]
        public IActionResult MessageBlock([FromForm]MessageViewModel message)
        {
            return PartialView("GetMessageHistoryBlock", message);
        }
    }
}
