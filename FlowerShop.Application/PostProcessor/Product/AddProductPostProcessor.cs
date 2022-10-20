using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using MediatR.Pipeline;

namespace FlowerShop.Application.PostProcessor.Product
{
    public class AddProductPostProcessor : IRequestPostProcessor<AddProductCommand, long>
    {
        public async Task Process(AddProductCommand request, long response, CancellationToken cancellationToken)
        {
           Console.WriteLine("sssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
           await Task.Delay(2);
        }
    }
}
