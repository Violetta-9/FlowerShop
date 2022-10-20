using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using MediatR;

namespace FlowerShop.Application.CommandHandler.Product
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, long>
    {
        public async Task<long> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return 1000000;
        }
    }
}
