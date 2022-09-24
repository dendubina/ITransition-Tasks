using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task5_Messages.EF.Entities;
using Task5_Messages.Models;
using Task5_Messages.Repositories.Interfaces;

namespace Task5_Messages.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessagesRepository _messagesRepository;

        public HomeController(IUserRepository userRepository, IMessagesRepository messagesRepository)
        {
            _userRepository = userRepository;
            _messagesRepository = messagesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ChosenUserViewModel model)
        {
            var user = await _userRepository.GetByNameAsync(model.Name);

            if (user is null)
            {
                await _userRepository.CreateAsync(model.Name);
                user = await _userRepository.GetByNameAsync(model.Name);
            }

            ViewBag.User = user;

            return View("Messages");
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageToSendViewModel model)
        {
            var receiver = await _userRepository.GetByNameAsync(model.ReceiverName);

            if (receiver is null)
            {
                await _userRepository.CreateAsync(model.ReceiverName);
                receiver = await _userRepository.GetByNameAsync(model.ReceiverName);
            }

            var message = new Message
            {
                AuthorId = model.AuthorId,
                RecipientId = receiver.Id,
                Date = DateTime.Now,
                Subject = model.Subject,
                Text = model.Text,
            };

            await  _messagesRepository.AddMessageAsync(message);

            ViewBag.User = new User{ Id = model.AuthorId };

            return View("Messages");
        }

        [HttpGet]
        public async Task<IActionResult> FindUsersBySubstring(string substring)
        {
            var users = await _userRepository.FindByNameAsync(substring);

            return Json(users.Select(x => x.Name));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
