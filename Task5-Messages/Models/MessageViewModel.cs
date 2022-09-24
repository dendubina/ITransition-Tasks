using System;

namespace Task5_Messages.Models
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string SenderName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
