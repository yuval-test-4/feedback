using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.Infrastructure.Models;

[Table("Customers")]
public class CustomerDbModel
{
    public List<CommentDbModel>? Comments { get; set; } = new List<CommentDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
