using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.ProductImage;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.QueriesHandler.ProductImage
{
    public class GetProductImageByProductIdQueriesHandler : IRequestHandler<GetProductImageByProductIdQueries, ProductImageDTO[]>
    {
        private readonly FlowerShopDbContext _db;
        public GetProductImageByProductIdQueriesHandler(FlowerShopDbContext db)
        {
            _db = db;
        }

        public async Task<ProductImageDTO[]> Handle(GetProductImageByProductIdQueries request, CancellationToken cancellationToken)
        {
            var productImage =await _db.ProductImages.Where(x => x.ProductId == request.ProductId)
                .ToArrayAsync(cancellationToken);
            
            return productImage.Select(x=>new ProductImageDTO(){Path = x.Path}).ToArray();
        }
    }
}
