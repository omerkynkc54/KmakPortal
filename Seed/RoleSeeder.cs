using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using KmakPortal.Models;
using KmakPortal.Data;
using Microsoft.AspNetCore.Identity;

namespace KmakPortal.Seed
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            string[] roleNames = { "Yönetim", "Üretim", "Satın Alma", "Satış" };

            foreach (var roleName in roleNames)
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = roleName });
                }
            }

            var adminUser = new User
            {
                UserName = "Ömer Kaynakçıoğlu",
                DepartmentId = 1, // Adjust as necessary
                RoleId = context.UserRoles.First(r => r.Role == "Yönetim").Id,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Admin@123")
            };

            if (!context.Users.Any(u => u.UserName == adminUser.UserName))
            {
                var result = await userManager.CreateAsync(adminUser);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Yönetim");
                }
            }

            context.SaveChanges();
        }
    }
}
