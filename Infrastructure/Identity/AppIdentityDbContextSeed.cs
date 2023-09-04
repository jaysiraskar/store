using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
          public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "jay",
                    Email = "jay@test.com",
                    UserName = "jay@test.com",
                    Address = new Address
                    {
                        FirstName = "Jay",
                        LastName = "Siraskar",
                        Street = "10 The street",
                        City = "New York",
                        State = "NY",
                        Zipcode = "90210"
                    }
                };

                await userManager.CreateAsync(user, "Jay@123");
            }
        }
    }
}