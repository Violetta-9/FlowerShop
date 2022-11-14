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
    public  class GetProductByCategoryIdQueriesHandler : IRequestHandler<GetProductByCategoryIdQuery, ProductDTO[]>
    {
        private readonly FlowerShopDbContext _db;
        public GetProductByCategoryIdQueriesHandler(FlowerShopDbContext db)
        {
            _db = db;
        }

        public async Task<ProductDTO[]> Handle(GetProductByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.Where(x => x.ProductCategoryId == request.CategoryId && !x.IsHidden)
                .ToArrayAsync(cancellationToken);
            return product.Select(x => new ProductDTO()
                { Description = x.Description, Title = x.Title, Price = x.Price,Id=x.Id }).ToArray();
        }
    }
}
