using Feedback.APIs.Dtos;
using Feedback.Infrastructure.Models;

namespace Feedback.APIs.Extensions;

public static class CommentsExtensions
{
    public static Comment ToDto(this CommentDbModel model)
    {
        return new Comment
        {
            Comments = model.Comments,
            CreatedAt = model.CreatedAt,
            Customer = model.CustomerId,
            Id = model.Id,
            Rate = model.Rate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CommentDbModel ToModel(
        this CommentUpdateInput updateDto,
        CommentWhereUniqueInput uniqueId
    )
    {
        var comment = new CommentDbModel
        {
            Id = uniqueId.Id,
            Comments = updateDto.Comments,
            Rate = updateDto.Rate
        };

        if (updateDto.CreatedAt != null)
        {
            comment.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            comment.CustomerId = updateDto.Customer;
        }
        if (updateDto.UpdatedAt != null)
        {
            comment.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return comment;
    }
}
