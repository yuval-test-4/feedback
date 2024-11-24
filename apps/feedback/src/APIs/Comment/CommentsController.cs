using Microsoft.AspNetCore.Mvc;

namespace Feedback.APIs;

[ApiController()]
public class CommentsController : CommentsControllerBase
{
    public CommentsController(ICommentsService service)
        : base(service) { }
}
