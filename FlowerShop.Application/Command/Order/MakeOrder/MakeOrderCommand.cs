using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlowerShop.Application.Command.Order.MakeOrder
{
    public class MakeOrderCommand:IRequest<long>
    {
        public string UserName { get; set; }
        public string Address { get; set; }

        public MakeOrderCommand(string userName, string address)
        {
            UserName = userName;
            Address = address;
        }
    }
}
