using FlowerShop.Application.Command.Product;
using FlowerShop.Application.Configurations.User;
using FlowerShop.Application.Contracts.Incoming.Product;
using FlowerShop.Application.Contracts.Incoming.User;
using FlowerShop.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class AdminController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add product")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
        [SwaggerOperation(Summary = "AddProduct", OperationId = "AddProduct")]
        public async Task<IActionResult> Login([FromForm] AddProductDTO product, [FromForm] IFormFile[] images)
        {
            
            var query = new AddProductCommand(product,images);

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
