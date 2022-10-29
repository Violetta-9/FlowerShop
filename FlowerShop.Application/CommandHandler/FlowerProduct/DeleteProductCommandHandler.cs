using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Services.Abstractions;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.CommandHandler.FlowerProduct
{
    public  class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand,Response>
    {
        private readonly IFileServices _blobService;
        private readonly FlowerShopDbContext _db;
        public DeleteProductCommandHandler(FlowerShopDbContext db, IFileServices blobFile)
        {
            _blobService=blobFile;
            _db = db;
        }

        public async Task<Response> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
            _db.Products.Remove(product);
            foreach (var image in product.ProductImages)
            {
                await _blobService.DeleteAsync(image.ContainerName, image.Path, cancellationToken);
            }
            await _db.SaveChangesAsync(cancellationToken);
            return Response.Success;
        }
    }
}
