using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.CommandHandler.FlowerProduct
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand,long>
    {
        private readonly FlowerShopDbContext _db;
        public UpdateProductCommandHandler(FlowerShopDbContext db)
        {
            _db = db;
        }

        public async Task<long> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            product.Title=request.NewProduct.Title;
            product.Description=request.NewProduct.Description;
            product.Price=request.NewProduct.Price;
            product.ProductCategoryId = request.NewProduct.ProductCategoryId;
            await _db.SaveChangesAsync(cancellationToken);
            return product.Id;

        }
    }
}
