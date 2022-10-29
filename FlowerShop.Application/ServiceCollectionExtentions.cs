using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using FlowerShop.Application.PipelineBehaviors;
using FlowerShop.Application.PostProcessor.Product;
using FlowerShop.Application.Queries;
using FlowerShop.Application.Validators.Commands.Product.AddProduct;
using FlowerShop.Application.Validators.Queries.User.LoginUser;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.Application
{
    public static  class ServiceCollectionExtentions
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            
            // serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            AssemblyScanner.FindValidatorsInAssembly(typeof(ServiceCollectionExtentions).Assembly)
                .ForEach(item => serviceCollection.AddScoped(item.InterfaceType, item.ValidatorType));
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //serviceCollection.AddScoped<IValidator<LoginUserQueries>, LoginUserValidator>();
            //serviceCollection.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();

            //serviceCollection.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();
            //serviceCollection.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();
            //serviceCollection.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();
            //serviceCollection.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();
            //serviceCollection.AddScoped<IValidator<AddProductCommand>, AddProductValidator>();
            //serviceCollection.AddTransient(typeof(IRequestPostProcessor<,>), typeof(AddProductPostProcessor));
            //serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
