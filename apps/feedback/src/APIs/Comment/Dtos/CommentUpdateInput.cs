namespace Feedback.APIs.Dtos;

public class CommentUpdateInput
{
    public string? Comments { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Customer { get; set; }

    public string? Id { get; set; }

    public string? Rate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
