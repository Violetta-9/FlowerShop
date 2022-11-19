using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Queries.ProductInCard.GetAllProductInCardByUserId
{
    public  class GetProductInCardByUserIdQuery : IRequest<ProductDTO[]>
    {
        public string UserName { get; set; }
        public GetProductInCardByUserIdQuery(string userName)
        {
            UserName = userName;
        }
    }
}
