using Feedback.APIs;

namespace Feedback;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<ICustomersService, CustomersService>();
    }
}
