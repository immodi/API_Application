using ApiApplication.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Repository.Identity
{
    public static class IdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Ahmed Yasser",
                    Email = "aaisas@lkasda.com",
                    UserName = "immodi",
                    PhoneNumber = "1214141414"
                };

                await userManager.CreateAsync(user, "P@ssw0rd");
            }
        }
    }
}
