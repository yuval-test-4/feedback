using Feedback.Infrastructure;
using Feedback.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Feedback;

public class SeedDevelopmentData
{
    public static async Task SeedDevUser(
        IServiceProvider serviceProvider,
        IConfiguration configuration
    )
    {
        var context = serviceProvider.GetRequiredService<FeedbackDbContext>();
        var userStore = new UserStore<IdentityUser>(context);
        var usernameValue = "test@email.com";
        var passwordValue = "P@ssw0rd!";

        var existingUser = await userStore.FindByEmailAsync(usernameValue.ToUpperInvariant());
        if (existingUser != null)
        {
            return;
        }

        var user = new IdentityUser
        {
            Email = usernameValue,
            UserName = usernameValue,
            NormalizedUserName = usernameValue.ToUpperInvariant(),
            NormalizedEmail = usernameValue.ToUpperInvariant(),
        };
        var password = new PasswordHasher<IdentityUser>();
        var hashed = password.HashPassword(user, passwordValue);
        user.PasswordHash = hashed;
        await userStore.CreateAsync(user);

        var amplicationRoles = configuration
            .GetSection("AmplicationRoles")
            .AsEnumerable()
            .Where(x => x.Value != null)
            .Select(x => x.Value.ToString())
            .ToArray();
        var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var role in amplicationRoles)
        {
            await userStore.AddToRoleAsync(user, _roleManager.NormalizeKey(role));
        }

        await context.SaveChangesAsync();
    }
}