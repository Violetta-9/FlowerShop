using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Application.Services.Abstractions;

namespace FlowerShop.Application.Services
{
    internal class BlobServices : IFileServices
    {
        private readonly BlobServiceClient _blobService;
        public BlobServices(BlobServiceClient blobService)
        {
            _blobService=blobService;
        }
        public async Task DeleteAsync(string containerName, string path, CancellationToken cancellationToken=default)
        {
            var blobClient=await GetBlobContainerClient(containerName, path);
            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);


        }

        public async Task<BlobDTO> GetBlobByPathAsync(string containerName, string path, CancellationToken cancellationToken=default)
        {
            var blobClient = await GetBlobContainerClient(containerName, path);
            var blobs =await blobClient.DownloadAsync(cancellationToken);
            return new BlobDTO
            {
                DownLoadStream = blobs.Value.Content,
                TypeOfContent = blobs.Value.ContentType
            };
        }

        public async Task UploadAsync(string containerName, string path, Stream content, CancellationToken cancellationToken=default)
        {
            var blobClient = await GetBlobContainerClient(containerName,path);
            await blobClient.UploadAsync(content, cancellationToken);

        } 

        private async Task<BlobClient> GetBlobContainerClient(string containerName,string path)
        {
            var client = _blobService.GetBlobContainerClient(containerName);
            await client.CreateIfNotExistsAsync();
            return client.GetBlobClient(path);
            
        }

       
    }
}
