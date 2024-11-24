using Feedback.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Infrastructure;

public class FeedbackDbContext : IdentityDbContext<IdentityUser>
{
    public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<CommentDbModel> Comments { get; set; }
}
