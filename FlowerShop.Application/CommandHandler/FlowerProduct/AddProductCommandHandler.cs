using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR;

namespace FlowerShop.Application.CommandHandler.FlowerProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, long>
    {
        private readonly FlowerShopDbContext _db;
        public AddProductCommandHandler(FlowerShopDbContext db)
        {
            _db = db;

        }
        public async Task<long> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Title = request.Product.Title,
                Description = request.Product.Description,
                Price = request.Product.Price,
                ProductCategoryId = request.Product.ProductCategoryId

            };
            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
