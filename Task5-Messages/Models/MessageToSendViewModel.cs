using System;
using System.ComponentModel.DataAnnotations;

namespace Task5_Messages.Models
{
    public class MessageToSendViewModel
    {
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string ReceiverName { get; set; }
    }
}
