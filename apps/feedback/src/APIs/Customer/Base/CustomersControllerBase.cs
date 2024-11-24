using Feedback.APIs;
using Feedback.APIs.Common;
using Feedback.APIs.Dtos;
using Feedback.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CustomersControllerBase : ControllerBase
{
    protected readonly ICustomersService _service;

    public CustomersControllerBase(ICustomersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one customer
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Customer>> CreateCustomer(CustomerCreateInput input)
    {
        var customer = await _service.CreateCustomer(input);

        return CreatedAtAction(nameof(Customer), new { id = customer.Id }, customer);
    }

    /// <summary>
    /// Delete one customer
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteCustomer([FromRoute()] CustomerWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteCustomer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many customers
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Customer>>> Customers(
        [FromQuery()] CustomerFindManyArgs filter
    )
    {
        return Ok(await _service.Customers(filter));
    }

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CustomersMeta(
        [FromQuery()] CustomerFindManyArgs filter
    )
    {
        return Ok(await _service.CustomersMeta(filter));
    }

    /// <summary>
    /// Get one customer
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Customer>> Customer(
        [FromRoute()] CustomerWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Customer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one customer
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateCustomer(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] CustomerUpdateInput customerUpdateDto
    )
    {
        try
        {
            await _service.UpdateCustomer(uniqueId, customerUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple comments records to customer
    /// </summary>
    [HttpPost("{Id}/comments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> ConnectComments(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] CommentWhereUniqueInput[] commentsId
    )
    {
        try
        {
            await _service.ConnectComments(uniqueId, commentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple comments records from customer
    /// </summary>
    [HttpDelete("{Id}/comments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DisconnectComments(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromBody()] CommentWhereUniqueInput[] commentsId
    )
    {
        try
        {
            await _service.DisconnectComments(uniqueId, commentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple comments records for customer
    /// </summary>
    [HttpGet("{Id}/comments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Comment>>> FindComments(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromQuery()] CommentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindComments(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple comments records for customer
    /// </summary>
    [HttpPatch("{Id}/comments")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateComments(
        [FromRoute()] CustomerWhereUniqueInput uniqueId,
        [FromBody()] CommentWhereUniqueInput[] commentsId
    )
    {
        try
        {
            await _service.UpdateComments(uniqueId, commentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
