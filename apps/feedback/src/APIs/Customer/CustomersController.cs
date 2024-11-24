using Microsoft.AspNetCore.Mvc;

namespace Feedback.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
