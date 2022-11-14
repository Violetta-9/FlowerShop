using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.Product;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.QueriesHandler.Product;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly FlowerShopDbContext _db;
    public GetProductByIdQueryHandler(FlowerShopDbContext db)
    {
        _db = db;
    }
    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {

        return await  _db.Products.Where(x => x.Id == request.Id).Select(x => new ProductDTO()
            { Description = x.Description, Id = x.Id, Price = x.Price, Title = x.Title, ProductCategoryId = x.ProductCategoryId}).FirstOrDefaultAsync(cancellationToken);
    }
}