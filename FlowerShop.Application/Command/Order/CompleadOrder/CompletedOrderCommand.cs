using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Command.Order.CompleadOrder
{
    public  class CompletedOrderCommand:IRequest<Response>
    {
        public long OrderId { get; set; }
        public CompletedOrderCommand(long orderId)
        {
            OrderId = orderId;
        }
    }
}
