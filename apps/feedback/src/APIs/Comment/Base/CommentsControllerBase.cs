using Feedback.APIs;
using Feedback.APIs.Common;
using Feedback.APIs.Dtos;
using Feedback.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CommentsControllerBase : ControllerBase
{
    protected readonly ICommentsService _service;

    public CommentsControllerBase(ICommentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one comment
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Comment>> CreateComment(CommentCreateInput input)
    {
        var comment = await _service.CreateComment(input);

        return CreatedAtAction(nameof(Comment), new { id = comment.Id }, comment);
    }

    /// <summary>
    /// Delete one comment
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteComment([FromRoute()] CommentWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteComment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many comments
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Comment>>> Comments(
        [FromQuery()] CommentFindManyArgs filter
    )
    {
        return Ok(await _service.Comments(filter));
    }

    /// <summary>
    /// Meta data about comment records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CommentsMeta(
        [FromQuery()] CommentFindManyArgs filter
    )
    {
        return Ok(await _service.CommentsMeta(filter));
    }

    /// <summary>
    /// Get one comment
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Comment>> Comment([FromRoute()] CommentWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Comment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one comment
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateComment(
        [FromRoute()] CommentWhereUniqueInput uniqueId,
        [FromQuery()] CommentUpdateInput commentUpdateDto
    )
    {
        try
        {
            await _service.UpdateComment(uniqueId, commentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a customer record for comment
    /// </summary>
    [HttpGet("{Id}/customer")]
    public async Task<ActionResult<List<Customer>>> GetCustomer(
        [FromRoute()] CommentWhereUniqueInput uniqueId
    )
    {
        var customer = await _service.GetCustomer(uniqueId);
        return Ok(customer);
    }
}
