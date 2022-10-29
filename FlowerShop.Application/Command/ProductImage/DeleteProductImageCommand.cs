using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Command.ProductImage
{
    public class DeleteProductImageCommand:IRequest<Response>
    {
        public long Id { get; set; }
        public DeleteProductImageCommand(long id)
        {
            Id = id;
        }
    }
}
