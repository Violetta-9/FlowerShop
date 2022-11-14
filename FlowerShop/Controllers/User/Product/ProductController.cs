using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.User.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{productCategoryId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductDTO[]))]
        [SwaggerOperation(Summary = "GetProductByCategoryId", OperationId = "GetProductByCategoryId")]
        public async Task<IActionResult> GetProductByCategoryId([FromRoute] long productCategoryId)
        {
            var query = new GetProductByCategoryIdQuery(productCategoryId);

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
        [HttpGet("Get Product Title and Id")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductTitleAndIdDTO[]))]
        [SwaggerOperation(Summary = "GetProductTitle", OperationId = "GetProductTitle")]
        public async Task<IActionResult> GetProductTitle()
        {
            var query = new GetAllProductTitleQuery();

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
