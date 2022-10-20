using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models.Abstractions;

namespace FlowerShop.Data.Domain.Models
{
    public  class ProductImage:PrimaryKey
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string ContainerName { get; set; }
        public long ProductId { get; set; }
        public virtual Product Products { get; set; }
    }
}
