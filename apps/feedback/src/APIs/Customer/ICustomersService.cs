using Feedback.APIs.Common;
using Feedback.APIs.Dtos;

namespace Feedback.APIs;

public interface ICustomersService
{
    /// <summary>
    /// Create one customer
    /// </summary>
    public Task<Customer> CreateCustomer(CustomerCreateInput customer);

    /// <summary>
    /// Delete one customer
    /// </summary>
    public Task DeleteCustomer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many customers
    /// </summary>
    public Task<List<Customer>> Customers(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    public Task<MetadataDto> CustomersMeta(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Get one customer
    /// </summary>
    public Task<Customer> Customer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one customer
    /// </summary>
    public Task UpdateCustomer(CustomerWhereUniqueInput uniqueId, CustomerUpdateInput updateDto);

    /// <summary>
    /// Connect multiple comments records to customer
    /// </summary>
    public Task ConnectComments(
        CustomerWhereUniqueInput uniqueId,
        CommentWhereUniqueInput[] commentsId
    );

    /// <summary>
    /// Disconnect multiple comments records from customer
    /// </summary>
    public Task DisconnectComments(
        CustomerWhereUniqueInput uniqueId,
        CommentWhereUniqueInput[] commentsId
    );

    /// <summary>
    /// Find multiple comments records for customer
    /// </summary>
    public Task<List<Comment>> FindComments(
        CustomerWhereUniqueInput uniqueId,
        CommentFindManyArgs CommentFindManyArgs
    );

    /// <summary>
    /// Update multiple comments records for customer
    /// </summary>
    public Task UpdateComments(
        CustomerWhereUniqueInput uniqueId,
        CommentWhereUniqueInput[] commentsId
    );
}
