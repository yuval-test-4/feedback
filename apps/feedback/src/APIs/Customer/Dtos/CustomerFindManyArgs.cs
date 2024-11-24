using Feedback.APIs.Common;
using Feedback.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindManyArgs : FindManyInput<Customer, CustomerWhereInput> { }
