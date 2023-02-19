using FlowerShop.Application.Command.Order.CompleadOrder;
using FlowerShop.Application.Configurations.User;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.FlowerOrders.GetAllOrdersQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.Admin.Order
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost("Get All Orders")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OrdersDTO[]))]
        [SwaggerOperation(Summary = "GetAllOrders", OperationId = "GetAllOrders")]
        public async Task<IActionResult> GetAllOrders([FromBody] bool IsComleated)
        {
            var query = new GetAllOrdersQuery(IsComleated);

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
        [HttpPost("Completed Order")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]
        [SwaggerOperation(Summary = "CompetedOrders", OperationId = "CompletedOrders")]
        public async Task<IActionResult> CompletedOrder([FromBody] long orderId)
        {
            var query = new CompletedOrderCommand(orderId);

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
