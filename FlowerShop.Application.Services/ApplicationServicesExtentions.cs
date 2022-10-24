using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Services.Abstractions;

namespace FlowerShop.Application.Services
{
    public static class ApplicationServicesExtentions
    {
        public static void AddApplicationServices(this IServiceCollection service)
        {
           
            service.AddSingleton<IFileServices, BlobServices>();
        }

    }
}
