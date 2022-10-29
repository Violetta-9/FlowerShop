using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Queries.Product
{
    public class GetProductByCategoryIdQuery : IRequest<ProductDTO[]>
    {
        public long CategoryId { get; set; }
        public GetProductByCategoryIdQuery(long categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
