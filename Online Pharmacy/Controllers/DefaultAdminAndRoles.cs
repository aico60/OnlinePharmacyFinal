using Microsoft.AspNetCore.Identity;
using Online_Pharmacy.Models;

namespace Online_Pharmacy.Controllers
{
    public static class DefaultAdminAndRoles
    {
        public static void SeedData(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<SiteUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@email.com").Result == null)
            {
                SiteUser user = new SiteUser();
                user.UserName = "admin@email.com";
                user.Email = "admin@email.com";
                user.FirstName = "Admin";
                user.FatherName = "Admin";
                user.LastName = "Admin";

                IdentityResult result = userManager.CreateAsync(user, "admin").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Client").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Client";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
