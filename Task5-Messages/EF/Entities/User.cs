using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Task5_Messages.EF.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Message> SentMessages { get; set; }

        [JsonIgnore]
        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
