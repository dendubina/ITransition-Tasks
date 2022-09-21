using System;
using Microsoft.AspNetCore.Identity;
using Task4AuthWebApp.Constants;

namespace Task4AuthWebApp.Entities
{
    public class User : IdentityUser
    {
        public DateTime LastSignInDate { get; set; }

        public DateTime SignUpDate { get; set; }

        public UserStatuses Status { get; set; }
    }
}
