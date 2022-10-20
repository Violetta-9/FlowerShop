using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Configurations
{
    public  class BlobStorageSettings
    {
       public string PathTemplate { get; set; }
       public string ProductImagesContainer { get; set; }
    }
}
