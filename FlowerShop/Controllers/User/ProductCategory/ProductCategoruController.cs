using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.FlowerProductCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.User.ProductCategory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoruController : Controller
    {
        private readonly IMediator _mediator;

        public ProductCategoruController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet("Get All Categories")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CategoriesDTO[]))]
        [SwaggerOperation(Summary = "GetAllCategories", OperationId = "GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllProductCategoriesQueries();

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
