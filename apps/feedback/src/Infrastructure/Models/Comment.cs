using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.Infrastructure.Models;

[Table("Comments")]
public class CommentDbModel
{
    [StringLength(1000)]
    public string? Comments { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerDbModel? Customer { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Rate { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
