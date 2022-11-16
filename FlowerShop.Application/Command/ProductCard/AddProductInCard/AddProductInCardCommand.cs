using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Incoming.ProductForCard;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Command.ProductCard.AddProductInCard
{
    public class AddProductInCardCommand:IRequest<Response>
    {
        public ProductForCardDTO newProduct { get; set; }

        public AddProductInCardCommand(ProductForCardDTO product)
        {
            newProduct=product;
        }
    }
}
