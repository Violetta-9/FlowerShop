using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.ProductImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.User.ProductImage
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : Controller
    {
        private readonly IMediator _mediator;

        public ProductImageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductImageDTO[]))]
        [SwaggerOperation(Summary = "GetImagesByProductId", OperationId = "GetImagesByProductId")]
        public async Task<IActionResult> GetImagesByProductId([FromRoute] long productId)
        {

            var query = new GetProductImageByProductIdQueries(productId);

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
