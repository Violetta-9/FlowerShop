using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Contracts.Outgoing
{
    public  class OrdersDTO
    {
        public long OrderId { get; set; }
        public string UserAdress { get; set; }
        public string[] FlowerTitle { get; set; }
        public string Phone { get; set; }
        public double TotalPrice { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
