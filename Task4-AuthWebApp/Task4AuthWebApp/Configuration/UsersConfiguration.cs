using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task4AuthWebApp.Constants;
using Task4AuthWebApp.Entities;

namespace Task4AuthWebApp.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(GetUsers());
        }

        private static IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    UserName = "Genie",
                    Email = "london_lesc3@gmail.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Blocked,
                },

                new User()
                {
                    UserName = "Anthony",
                    Email = "haylee.nitzsc@yahoo.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Active,
                },

                new User()
                {
                    UserName = "Kelly",
                    Email = "harvey1982@hotmail.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Active,
                },

                new User()
                {
                    UserName = "Paul",
                    Email = "daisy_bernha@gmail.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Active,
                },

                new User()
                {
                    UserName = "Freida",
                    Email = "rosa_turne6@gmail.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Active,
                },

                new User()
                {
                    UserName = "Margaret",
                    Email = "colin_lin6@hotmail.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Active,
                },

                new User()
                {
                    UserName = "Peter",
                    Email = "arjun_kertzma@gmail.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Active,
                },

                new User()
                {
                    UserName = "Deloris",
                    Email = "emil2002@hotmail.com",
                    LastSignInDate = DateTime.Now,
                    SignUpDate = DateTime.Now,
                    Status = UserStatuses.Active,
                },
            };
        }
    }
}
