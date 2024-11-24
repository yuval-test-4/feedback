namespace Feedback.APIs.Dtos;

public class Customer
{
    public List<string>? Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
