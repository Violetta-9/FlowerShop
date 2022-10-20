using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FlowerShop.Application.Contracts.Incoming.Product
{
    public class AddProductDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public long? ProductId { get; set; }
       
    }
}
