using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models.Abstractions;

namespace FlowerShop.Data.Domain.Models
{
    public  class Order: PrimaryKey
    {
        public long UserId { get; set; }
        public long FlowerId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
