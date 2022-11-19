using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Command.ProductCard.DeleteProductFromCard
{
    public class DeleteProductFromCardCommand: IRequest<Response>
    {
        public string UserName { get; set; }
        public long ProductId { get; set; }
        public DeleteProductFromCardCommand(string username, long productId)
        {
            UserName = username;
            ProductId = productId;
        }
    }
}
