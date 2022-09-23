using System;
using System.Collections.Generic;

namespace Task5_Messages.EF.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Message> SentMessages { get; set; }

        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
