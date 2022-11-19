using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlowerShop.Application.Command.ProductCard.ChangeQuentity
{
    public class ChangeQuentityCommand:IRequest<int>
    {
        public string UserName { get; set; }
        public int Number { get; set; }
        public long ProductId { get; set; }
        public ChangeQuentityCommand(int number,string userName, long productId)
        {
            Number = number;
            UserName = userName;
            ProductId = productId;
        }
    }
}
