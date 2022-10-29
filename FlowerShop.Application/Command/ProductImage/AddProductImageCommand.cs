using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FlowerShop.Application.Command.ProductImage
{
    public class AddProductImageCommand:IRequest<Response>
    {
        public long ProductId { get; set; }
        public IFormFile[] Images { get; set; }
        public AddProductImageCommand(long productId, IFormFile[] images)
        {
            ProductId = productId;
            Images = images;
        }
    }
}
