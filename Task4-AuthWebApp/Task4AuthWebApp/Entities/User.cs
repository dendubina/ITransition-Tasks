using System;
using Microsoft.AspNetCore.Identity;

namespace Task4AuthWebApp.Entities
{
    public class User : IdentityUser
    {
        public DateTime LastSignInDate { get; set; }

        public DateTime SignUpDate { get; set; }

        public string Status { get; set; }
    }
}
