using Microsoft.AspNetCore.Identity;

using ProductsAPI.Models;
using ProductsAPI.Models.Config;

namespace ProductsAPI.Data;

public static class ApiDbInitializer
{
    public static async Task SeedRolesAsync(IApplicationBuilder app, List<RoleConfig> roles)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
        RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (RoleConfig role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name))
            {
                _ = await roleManager.CreateAsync(new IdentityRole(role.Name));
            }
        }
    }
    public static async Task SeedDbDevelopmentAsync(IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>()!;
        UserManager<User> userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>()!;
        ApiDbContext? context = serviceScope.ServiceProvider.GetService<ApiDbContext>();
        IConfiguration? config = serviceScope.ServiceProvider.GetService<IConfiguration>();

        // get test users array from config file and loop through to create users
        foreach (TestUserConfig userConfig in config!.GetSection("TestUsers").Get<TestUserConfig[]>()!)
        {
            string email = userConfig.Email;
            string username = userConfig.UserName;
            string password = userConfig.Password;
            string roleName = userConfig.RoleName;
            User userToCreate = new()
            {
                UserName = username,
                Email = email,
                RoleName = roleName
            };
            User? userInDb = await userManager.FindByEmailAsync(email);
            if (userInDb == null)
            {
                IdentityResult result = await userManager.CreateAsync(userToCreate, password);
                if (result.Succeeded)
                {
                    //* roles added in SeedRolesAsync method
                    // if (await roleManager.FindByNameAsync(roleName) == null)
                    // {
                    //   await roleManager.CreateAsync(new IdentityRole(roleName));
                    // }
                    _ = await userManager.AddToRoleAsync(userToCreate, roleName);
                }
            }
            else
            {
                // update user
                // userInDb.UserName = username;
                // userInDb.Email = email;
                // userInDb.RoleName = roleName;
                // await userManager.UpdateAsync(userInDb);

                // // update password
                // var token = await userManager.GeneratePasswordResetTokenAsync(userInDb);
                // await userManager.ResetPasswordAsync(userInDb, token, password);

                // // update role
                // var userRoles = await userManager.GetRolesAsync(userInDb);
                // await userManager.RemoveFromRolesAsync(userInDb, userRoles);
                // await userManager.AddToRoleAsync(userInDb, roleName);

                // // update claims
                // var claims = await userManager.GetClaimsAsync(userInDb);
                // await userManager.RemoveClaimsAsync(userInDb, claims);
                // await userManager.AddClaimAsync(userInDb, new Claim(ClaimTypes.Role, roleName));

                // // update tokens
                // var tokens = await userManager.GetAuthenticationTokensAsync(userInDb);
                // await userManager.RemoveAuthenticationTokenAsync(userInDb, "Google", "access_token");
                // await userManager.RemoveAuthenticationTokenAsync(userInDb, "Google", "refresh_token");

                // await userManager.SetAuthenticationTokenAsync(userInDb, "Google", "access_token", userConfig.GoogleAccessToken);
                // await userManager.SetAuthenticationTokenAsync(userInDb, "Google", "refresh_token", userConfig.GoogleRefreshToken);
            }
        }
    }
}