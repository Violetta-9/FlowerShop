using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Contracts.Incoming.ProductForCard
{
    public class ProductForCardDTO
    {
        public long ProductId { get; set; }
        public int Quentity { get; set; }
        public string UserName { get; set; }
    }
}
