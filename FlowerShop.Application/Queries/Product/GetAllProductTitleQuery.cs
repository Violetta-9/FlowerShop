using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Queries.Product
{
    public class GetAllProductTitleQuery : IRequest<ProductTitleAndIdDTO[]>
    {
    }
}
