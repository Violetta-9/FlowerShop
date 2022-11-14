using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Configurations;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Queries.ProductImage;
using FlowerShop.Application.Services.Abstractions;
using FlowerShop.Data.Share.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.QueriesHandler.ProductImage
{
    public class GetProductImageByProductIdQueriesHandler : IRequestHandler<GetProductImageByProductIdQueries, ProductImageDTO[]>
    {
        private readonly FlowerShopDbContext _db;
        private readonly IFileServices _blobService;
  

        public GetProductImageByProductIdQueriesHandler(FlowerShopDbContext db, IFileServices blob)
        {
            _db = db;
            _blobService = blob;
          
        }

        public async Task<ProductImageDTO[]> Handle(GetProductImageByProductIdQueries request,
            CancellationToken cancellationToken)
        {

            var productImage = await _db.ProductImages.Where(x => x.ProductId == request.ProductId)
                .ToArrayAsync(cancellationToken);
            var dtoTasks = productImage.Select(x => MapToDTOAsync(x, cancellationToken));

            var dtos = await Task.WhenAll(dtoTasks);
            foreach (var x in dtos)
            {
                Console.WriteLine(x.AbsoluteUri);
                Console.WriteLine(x.FileName);


            }
           
            return dtos.ToArray();


        }

        private async Task<ProductImageDTO> MapToDTOAsync(Data.Domain.Models.ProductImage entity,
            CancellationToken cancellationToken)
        {
            var blobInfo =
                await _blobService.GetBlobByPathAsync(entity.ContainerName, entity.Path, cancellationToken);

            return new ProductImageDTO
            {
                AbsoluteUri = blobInfo.AbsoluteUri,
                FileName = entity.FileName
            };
        }
    }
}
