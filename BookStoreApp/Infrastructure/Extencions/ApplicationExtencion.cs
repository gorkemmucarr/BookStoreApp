using Microsoft.AspNetCore.Identity;

namespace BookStoreApp.Infrastructure.Extencions
{
    public static class ApplicationExtencion
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123";

            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();


            IdentityUser user = await userManager.FindByNameAsync(adminUser); //admin'i bul
            if (user is null) //eger admin yoksa yeni bir admin olustur
            {
                user = new IdentityUser()
                {
                    Email = "admin@admin.com",
                    UserName = adminUser
                };

                var result = await userManager.CreateAsync(user,adminPassword); //olusturulan admin'i veritabanına kaydet
                if (!result.Succeeded)
                {
                    throw new Exception("Admin could not create");
                }

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager.Roles.Select(p => p.Name).ToList());  //admin'e tum rolleri veriyoruz
                if (!result.Succeeded)
                {
                    throw new Exception("System have a problem");
                }
            }
                
        }
    }
}
