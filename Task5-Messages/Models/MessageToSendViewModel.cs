using System;
using System.ComponentModel.DataAnnotations;

namespace Task5_Messages.Models
{
    public class MessageToSendViewModel
    {
        [Required]
        public Guid AuthorId { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public string ReceiverName { get; set; }
    }
}
