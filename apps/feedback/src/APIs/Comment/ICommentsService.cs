using Feedback.APIs.Common;
using Feedback.APIs.Dtos;

namespace Feedback.APIs;

public interface ICommentsService
{
    /// <summary>
    /// Create one comment
    /// </summary>
    public Task<Comment> CreateComment(CommentCreateInput comment);

    /// <summary>
    /// Delete one comment
    /// </summary>
    public Task DeleteComment(CommentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many comments
    /// </summary>
    public Task<List<Comment>> Comments(CommentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about comment records
    /// </summary>
    public Task<MetadataDto> CommentsMeta(CommentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one comment
    /// </summary>
    public Task<Comment> Comment(CommentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one comment
    /// </summary>
    public Task UpdateComment(CommentWhereUniqueInput uniqueId, CommentUpdateInput updateDto);

    /// <summary>
    /// Get a customer record for comment
    /// </summary>
    public Task<Customer> GetCustomer(CommentWhereUniqueInput uniqueId);
}
