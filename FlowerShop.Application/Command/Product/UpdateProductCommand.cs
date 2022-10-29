using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Incoming.Product;
using MediatR;

namespace FlowerShop.Application.Command.Product
{
    public class UpdateProductCommand:IRequest<long>
    {
        public long Id { get; set; }
        public AddProductDTO NewProduct { get; set; }
        public UpdateProductCommand(long id, AddProductDTO newProduct)
        {
            Id = id;
            NewProduct = newProduct;
        }
    }
}
