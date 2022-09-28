using System;

namespace Task_6_RandomData.Models
{
    public class PersonInfo
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
    }
}
