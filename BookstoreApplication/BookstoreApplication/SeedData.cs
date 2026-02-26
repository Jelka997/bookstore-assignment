using BookstoreApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace BookstoreApplication
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var role = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var user = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var editor1 = await user.FindByNameAsync("ilija");
            if (editor1 == null)
            {
                editor1 = new ApplicationUser
                {
                    UserName = "ilija",
                    Email = "ilija.petrovic@gmail.com",
                    Name = "Ilija",
                    Surname = "Petrovic",
                    EmailConfirmed = true,
                };
                await user.CreateAsync(editor1, "Ilija123");
            }
            if (!await user.IsInRoleAsync(editor1, "Editor"))
            {
                await user.AddToRoleAsync(editor1, "Editor");
            }


            var editor2 = await user.FindByNameAsync("aleksa");
            if (editor2 == null)
            {
                editor2 = new ApplicationUser
                {
                    UserName = "aleksa",
                    Email = "aleksa.stanojoski@gmail.com",
                    Name = "Aleksa",
                    Surname = "Stanojoski",
                    EmailConfirmed = true,
                };
                await user.CreateAsync(editor2, "Aleksa123");
            }
            if (!await user.IsInRoleAsync(editor2, "Editor"))
            {
                await user.AddToRoleAsync(editor2, "Editor");
            }

            var editor3 = await user.FindByNameAsync("olga");
            if (editor3 == null)
            {
                editor3 = new ApplicationUser
                {
                    UserName = "Olga",
                    Email = "olga.majkic@gmail.com",
                    Name = "Olga",
                    Surname = "Majkic",
                    EmailConfirmed = true,
                };
                await user.CreateAsync(editor3, "Olga123");
            }
            if (!await user.IsInRoleAsync(editor3, "Editor"))
            {
                await user.AddToRoleAsync(editor3, "Editor");
            }
        }
    }
}