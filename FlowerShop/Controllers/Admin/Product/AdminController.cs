﻿using FlowerShop.Application.Command.Product;
using FlowerShop.Application.Configurations.User;
using FlowerShop.Application.Contracts.Incoming.Product;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlowerShop.Controllers.Admin.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add product")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "AddProduct", OperationId = "AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDTO product, [FromForm] IFormFileCollection images)
        {

            var query = new AddProductCommand(product, images);

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
        [HttpDelete("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Response))]
        [SwaggerOperation(Summary = "DeleteProduct", OperationId = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long productId)
        {
            var query = new DeleteProductCommand(productId);

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

        [HttpPut("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerOperation(Summary = "UpdateProduct", OperationId = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm] AddProductDTO product, [FromRoute] long productId)
        {
            var query = new UpdateProductCommand(productId, product);

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
        [HttpGet("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [SwaggerOperation(Summary = "GetProductById", OperationId = "GetProductById")]
        public async Task<IActionResult> GetProductById([FromRoute] long productId)
        {
            var query = new GetProductByIdQuery(productId);

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
