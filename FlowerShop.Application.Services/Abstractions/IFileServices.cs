using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;

namespace FlowerShop.Application.Services.Abstractions
{
    public  interface IFileServices
    {
        Task<BlobDTO> GetBlobByPathAsync(string containerName,string path,CancellationToken cancellationToken);
         Task UploadAsync(string containerName,string path,Stream content,CancellationToken cancellationToken);
         Task DeleteAsync(string containerName,string path,CancellationToken cancellationToken);
    }
}
