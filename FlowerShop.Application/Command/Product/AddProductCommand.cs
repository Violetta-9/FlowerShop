using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Incoming.Product;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FlowerShop.Application.Command.Product
{
    public class AddProductCommand:IRequest<long>
    {
        public AddProductDTO Product { get; set; }
        public IFormFile[] Files;
        public AddProductCommand(AddProductDTO product,IFormFile[] files)
        {
            Product=product;
            Files=files;
        }
    }
}
