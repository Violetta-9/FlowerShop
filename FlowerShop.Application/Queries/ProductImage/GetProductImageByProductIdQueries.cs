using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Queries.ProductImage
{
    public class GetProductImageByProductIdQueries : IRequest<ProductImageDTO[]>
    {
        public long ProductId { get; set; }
        public GetProductImageByProductIdQueries(long productId)
        {
            ProductId = productId;
        }
    }
}
