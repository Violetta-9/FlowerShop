using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using FlowerShop.Application.Configurations;
using FlowerShop.Application.Services.Abstractions;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.DbContext;
using MediatR.Pipeline;
using Microsoft.Extensions.Options;

namespace FlowerShop.Application.PostProcessor.Product
{
    public class AddProductPostProcessor : IRequestPostProcessor<AddProductCommand, long>
    {
        private readonly FlowerShopDbContext _db;
        private readonly IFileServices _blobService;
        private readonly BlobStorageSettings _blobStorageSettings;


        public AddProductPostProcessor(FlowerShopDbContext db,IFileServices blobFile, IOptions<BlobStorageSettings> blobSettings)
        {
            _db=db;
            _blobService=blobFile;
            _blobStorageSettings=blobSettings.Value;
        }
        public async Task Process(AddProductCommand request, long response, CancellationToken cancellationToken)
        {
            var containerName = _blobStorageSettings.ProductImagesContainer; 
            foreach (var file in request.Files)
            {
                var path = string.Format(_blobStorageSettings.PathTemplate, response, file.FileName);
                try
                {

                    await using (var filestream = file.OpenReadStream())
                    {
                        await _blobService.UploadAsync(containerName, path, filestream, cancellationToken);
                    }

                    var productImage = new ProductImage()
                    {
                        ContainerName = containerName,
                        FileName = file.FileName,
                        Path = path,
                        ProductId = response

                    };
                    await _db.ProductImages.AddAsync(productImage);
                    await _db.SaveChangesAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                   await _blobService.DeleteAsync(containerName, path, cancellationToken);
                }
            }
            
        }
    }
}
