using FlowerShop.Application.Command.ProductCard.AddProductInCard;
using FlowerShop.Application.Contracts.Incoming.ProductForCard;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.FlowerProductCategory;
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
    }
}
