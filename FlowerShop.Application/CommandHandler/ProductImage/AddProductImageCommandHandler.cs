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
    public class AddProductImageCommandHandler:IRequestHandler<AddProductImageCommand,Response>
    {
        private readonly FlowerShopDbContext _db;
        private readonly IFileServices _blobService;
        private readonly BlobStorageSettings _blobStorageSettings;
        public AddProductImageCommandHandler(FlowerShopDbContext db, IFileServices blobFile, IOptions<BlobStorageSettings> blobSettings)
        {
            _db = db;
            _blobService = blobFile;
            _blobStorageSettings = blobSettings.Value;
        }

        public async Task<Response> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
           
            var containerName = _blobStorageSettings.ProductImagesContainer;
            foreach (var file in request.Images)
            {
                var path = string.Format(_blobStorageSettings.PathTemplate, request.ProductId, file.FileName);
                try
                {

                    await using (var filestream = file.OpenReadStream())
                    {
                        await _blobService.UploadAsync(containerName, path, filestream, cancellationToken);
                    }

                    var productImage = new Data.Domain.Models.ProductImage()
                    {
                        ContainerName = containerName,
                        FileName = file.FileName,
                        Path = path,
                        ProductId = request.ProductId,

                    };
                    await _db.ProductImages.AddAsync(productImage,cancellationToken);
                    await _db.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    await _blobService.DeleteAsync(containerName, path, cancellationToken);
                    return Response.Error;
                }
            }
            return Response.Success;
        
        }
    }
}
