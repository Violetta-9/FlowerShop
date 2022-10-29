using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlowerShop.Application.Command.User;
using FlowerShop.Application.Contracts.Incoming.User;
using FlowerShop.Application.Queries;
using FlowerShop.Application.Queries.FlowerProductCategory;
using FlowerShop.Application.Queries.Product;
using FlowerShop.Application.Queries.ProductImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost("registration")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
        [SwaggerOperation(Summary = "Register new user", OperationId = "RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody]AddUserDTO newUser)
        {
            var query = new RegisterCommand(newUser);
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
        [HttpPost("login")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
        [SwaggerOperation(Summary = "Login", OperationId = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginData)
        {
            var query = new LoginUserQueries(loginData);

            if(query == null)
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
        [HttpGet("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
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
        [HttpGet("Get All Categories")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
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
        
        [HttpGet("{productCategoryId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
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
    }

}
