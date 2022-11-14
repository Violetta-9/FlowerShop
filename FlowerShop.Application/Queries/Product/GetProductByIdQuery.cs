using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Queries.Product
{
    public class GetProductByIdQuery:IRequest<ProductDTO>
    {
        public long Id { get; set; }

        public GetProductByIdQuery(long id)
        {
            Id=id;
        }
    }
}
