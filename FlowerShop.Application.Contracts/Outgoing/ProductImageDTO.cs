using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Contracts.Outgoing
{
    public class ProductImageDTO
    {
        public string FileName { get; set; }
        public string AbsoluteUri { get; set; }
    }
}
