using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.ProductImage;
using FlowerShop.Application.Configurations;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Services.Abstractions;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FlowerShop.Application.CommandHandler.ProductImage
{
    public class DeleteProductImageCommandHandler:IRequestHandler<DeleteProductImageCommand,Response>
    {
        private readonly FlowerShopDbContext _db;
        private readonly IFileServices _blobService;
        private readonly BlobStorageSettings _blobStorageSettings;

        public DeleteProductImageCommandHandler(FlowerShopDbContext db, IFileServices blobFile, IOptions<BlobStorageSettings> blobSettings)
        {
            _blobService = blobFile;
            _blobStorageSettings = blobSettings.Value;
            _db =db;
        }
        public async Task<Response> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage =await _db.ProductImages.SingleOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
            _db.ProductImages.Remove(productImage);
           await _db.SaveChangesAsync(cancellationToken);
           await _blobService.DeleteAsync(productImage.ContainerName, productImage.Path, cancellationToken);
           return Response.Success;
           

        }
    }
}
