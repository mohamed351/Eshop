using EShop.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Data
{
    public  class IdentityContextSeedData
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    Email = "mohamed.beshri.amer@gmail.com",
                    DisplayName = "Mohamed Beshri Amer",
                    PhoneNumber = "0100111212141",
                    UserName = "mohamed123",
                    Address = new Address() {
                        City ="Alexandria",
                        ZipCode = "1234",
                        Street ="Alexandria"
                    }

                };
               await userManager.CreateAsync(user, "P@$$w0rd");
            }
        }
    }
}
