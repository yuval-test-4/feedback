using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Infrastructure;

public class FeedbackDbContext : IdentityDbContext<IdentityUser>
{
    public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options)
        : base(options) { }
}
