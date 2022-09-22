using System;
using Task4AuthWebApp.Constants;

namespace Task4AuthWebApp.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime LastSignInDate { get; set; }

        public DateTime SignUpDate { get; set; }

        public UserStatuses Status { get; set; }

        public bool Selected { get; set; }

    }
}
