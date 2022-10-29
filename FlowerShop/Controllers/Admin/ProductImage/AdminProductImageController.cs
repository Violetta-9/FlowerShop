using FlowerShop.Application.Command.ProductImage;
using FlowerShop.Application.Configurations.User;
using FlowerShop.Application.Queries.ProductImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.Admin.ProductImage
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class AdminProductImageController : Controller
    {
        private readonly IMediator _mediator;

        public AdminProductImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{productImageId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
        [SwaggerOperation(Summary = "DeleteProductImage", OperationId = "DeleteProductImage")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] long productImageId)
        {
            var query = new DeleteProductImageCommand(productImageId);

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
        [HttpPost("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
        [SwaggerOperation(Summary = "AddImageByProductId", OperationId = "AddImageByProductId")]
        public async Task<IActionResult> AddImageByProductId([FromRoute] long productId, [FromForm] IFormFile[] images)
        {
            var query = new AddProductImageCommand(productId, images);

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
