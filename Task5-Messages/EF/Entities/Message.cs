using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5_Messages.EF.Entities
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        public User Author { get; set; }

        [ForeignKey(nameof(Recipient))]
        public Guid RecipientId { get; set; }

        public User Recipient { get; set; }
    }
}
