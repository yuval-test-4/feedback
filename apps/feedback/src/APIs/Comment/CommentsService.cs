using Feedback.Infrastructure;

namespace Feedback.APIs;

public class CommentsService : CommentsServiceBase
{
    public CommentsService(FeedbackDbContext context)
        : base(context) { }
}
