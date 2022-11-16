using FlowerShop.Application.Command.Order.MakeOrder;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.User.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]
        [SwaggerOperation(Summary = "MakeOrder", OperationId = "MakeOrder")]
        public async Task<IActionResult> MakeOrder([FromForm] string userName, [FromForm]string address)
        {
            var query = new MakeOrderCommand(userName,address);

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound(result);
            }

            return Ok(result);



        }
    }
}
