using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Command.Product
{
    public  class DeleteProductCommand:IRequest<Response>
    {
        public long Id { get; set; }
        public DeleteProductCommand(long id)
        {
            Id = id;
        }
    }
}
