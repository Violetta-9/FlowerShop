using FlowerShop.Application.Command.ProductCard.AddProductInCard;
using FlowerShop.Application.Command.ProductCard.ChangeQuentity;
using FlowerShop.Application.Command.ProductCard.DeleteProductFromCard;
using FlowerShop.Application.Contracts.Incoming.ProductForCard;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.FlowerProductCategory;
using FlowerShop.Application.Queries.ProductInCard.GetAllProductInCardByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.User.ProductInCard
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductInCardController : Controller
    {
        private readonly IMediator _mediator;

        public ProductInCardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("Add Product in Card")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]
        [SwaggerOperation(Summary = "AddProductInCard", OperationId = "AddProductInCard")]
        public async Task<IActionResult> AddProductInCard([FromForm] ProductForCardDTO product)
        { 
            var query = new AddProductInCardCommand(product);

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
        [HttpDelete("Delete Product in Card")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]
        [SwaggerOperation(Summary = "DeleteProductInCard", OperationId = "DeleteProductInCard")]
        public async Task<IActionResult> DeleteProductInCard([FromForm] string userName, [FromForm] long productId)
        {
            var query = new DeleteProductFromCardCommand(userName,productId);

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
        [HttpPut("Change quantity for product in card")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(int))]
        [SwaggerOperation(Summary = "ChangeQuantity", OperationId = "ChangeQuantity")]
        public async Task<IActionResult> ChangeQuantity([FromForm] string userName, [FromForm] long productId,[FromForm] int quentity)
        {
            var query = new ChangeQuentityCommand(quentity,userName,productId);

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
        [HttpPost("Show Products in Card")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductDTO[]))]
        [SwaggerOperation(Summary = "ShowProductsInCard", OperationId = "ShowProductsInCard")]
        public async Task<IActionResult> ShowProducts([FromBody] string userName)
        {
            var query = new GetProductInCardByUserIdQuery(userName);

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
