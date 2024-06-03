using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using KmakPortal.Models;
using KmakPortal.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KmakPortal.Seed
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            // Seed departments if none exist
            if (!await context.Departments.AnyAsync())
            {
                context.Departments.AddRange(
                    new Department { DepartmentName = "Montaj" },
                    new Department { DepartmentName = "Kaynaklı İmalat" },
                    new Department { DepartmentName = "Talaşlı İmalat" }
                );
                await context.SaveChangesAsync();
            }

            string[] roleNames = { "Yönetim", "Üretim", "Satın Alma", "Satış" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = roleName });
                }
            }

            var adminUser = new User
            {
                UserName = "Ömer Kaynakçıoğlu",
                DepartmentId = context.Departments.First().Id, // Adjust as necessary
            };

            var user = await userManager.FindByNameAsync(adminUser.UserName);
            if (user == null)
            {
                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Yönetim");
            }

            context.SaveChanges();
        }
    }
}
