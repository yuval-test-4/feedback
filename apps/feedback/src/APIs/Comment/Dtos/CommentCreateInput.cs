namespace Feedback.APIs.Dtos;

public class CommentCreateInput
{
    public string? Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public Customer? Customer { get; set; }

    public string? Id { get; set; }

    public string? Rate { get; set; }

    public DateTime UpdatedAt { get; set; }
}
