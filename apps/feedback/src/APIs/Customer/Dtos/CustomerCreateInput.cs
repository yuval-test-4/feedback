namespace Feedback.APIs.Dtos;

public class CustomerCreateInput
{
    public List<Comment>? Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
