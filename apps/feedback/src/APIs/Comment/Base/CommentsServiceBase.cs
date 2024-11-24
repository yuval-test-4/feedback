using Feedback.APIs;
using Feedback.APIs.Common;
using Feedback.APIs.Dtos;
using Feedback.APIs.Errors;
using Feedback.APIs.Extensions;
using Feedback.Infrastructure;
using Feedback.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.APIs;

public abstract class CommentsServiceBase : ICommentsService
{
    protected readonly FeedbackDbContext _context;

    public CommentsServiceBase(FeedbackDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one comment
    /// </summary>
    public async Task<Comment> CreateComment(CommentCreateInput createDto)
    {
        var comment = new CommentDbModel
        {
            Comments = createDto.Comments,
            CreatedAt = createDto.CreatedAt,
            Rate = createDto.Rate,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            comment.Id = createDto.Id;
        }
        if (createDto.Customer != null)
        {
            comment.Customer = await _context
                .Customers.Where(customer => createDto.Customer.Id == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CommentDbModel>(comment.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one comment
    /// </summary>
    public async Task DeleteComment(CommentWhereUniqueInput uniqueId)
    {
        var comment = await _context.Comments.FindAsync(uniqueId.Id);
        if (comment == null)
        {
            throw new NotFoundException();
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many comments
    /// </summary>
    public async Task<List<Comment>> Comments(CommentFindManyArgs findManyArgs)
    {
        var comments = await _context
            .Comments.Include(x => x.Customer)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return comments.ConvertAll(comment => comment.ToDto());
    }

    /// <summary>
    /// Meta data about comment records
    /// </summary>
    public async Task<MetadataDto> CommentsMeta(CommentFindManyArgs findManyArgs)
    {
        var count = await _context.Comments.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one comment
    /// </summary>
    public async Task<Comment> Comment(CommentWhereUniqueInput uniqueId)
    {
        var comments = await this.Comments(
            new CommentFindManyArgs { Where = new CommentWhereInput { Id = uniqueId.Id } }
        );
        var comment = comments.FirstOrDefault();
        if (comment == null)
        {
            throw new NotFoundException();
        }

        return comment;
    }

    /// <summary>
    /// Update one comment
    /// </summary>
    public async Task UpdateComment(CommentWhereUniqueInput uniqueId, CommentUpdateInput updateDto)
    {
        var comment = updateDto.ToModel(uniqueId);

        if (updateDto.Customer != null)
        {
            comment.Customer = await _context
                .Customers.Where(customer => updateDto.Customer == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(comment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Comments.Any(e => e.Id == comment.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a customer record for comment
    /// </summary>
    public async Task<Customer> GetCustomer(CommentWhereUniqueInput uniqueId)
    {
        var comment = await _context
            .Comments.Where(comment => comment.Id == uniqueId.Id)
            .Include(comment => comment.Customer)
            .FirstOrDefaultAsync();
        if (comment == null)
        {
            throw new NotFoundException();
        }
        return comment.Customer.ToDto();
    }
}
