using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.Product;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.QueriesHandler.Product
{
    public class GetAllProductTitleQueryHandler : IRequestHandler<GetAllProductTitleQuery, ProductTitleAndIdDTO[]>
    {
        private readonly FlowerShopDbContext _db;
        public GetAllProductTitleQueryHandler(FlowerShopDbContext db)
        {
            _db = db;
        }
        public async Task<ProductTitleAndIdDTO[]> Handle(GetAllProductTitleQuery request, CancellationToken cancellationToken)
        {
            return await _db.Products.Select(x => new ProductTitleAndIdDTO() { ProductId = x.Id, Title = x.Title }).ToArrayAsync(cancellationToken);
        }
    }
}
