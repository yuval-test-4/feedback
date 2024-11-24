using Feedback.Infrastructure;

namespace Feedback.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(FeedbackDbContext context)
        : base(context) { }
}
