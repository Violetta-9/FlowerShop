using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Queries.FlowerOrders.GetAllOrdersQuery
{
    public  class GetAllOrdersQuery:IRequest<IEnumerable<OrdersDTO>>
    {
        public bool IsCompleated { get; set; }
        public GetAllOrdersQuery(bool isCompleated)
        {
            IsCompleated = isCompleated;
        }
    }
}
