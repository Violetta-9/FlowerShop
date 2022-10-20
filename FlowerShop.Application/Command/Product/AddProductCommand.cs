using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Incoming.Product;
using MediatR;

namespace FlowerShop.Application.Command.Product
{
    public class AddProductCommand:IRequest<long>
    {
        public AddProductCommand(AddProductDTO product)
        {

        }
    }
}
