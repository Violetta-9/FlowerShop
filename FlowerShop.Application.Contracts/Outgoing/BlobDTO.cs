using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Contracts.Outgoing
{
    public class BlobDTO
    {
        public Stream DownLoadStream { get; set; }
        public string TypeOfContent { get; set; }
        
    }
}
