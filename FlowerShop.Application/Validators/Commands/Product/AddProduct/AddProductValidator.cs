using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using FlowerShop.Application.Resources;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Application.Validators.Commands.Product.AddProduct
{
    public  class AddProductValidator:AbstractValidator<AddProductCommand>
    {
       
        public AddProductValidator()
        {
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.Files)
                .Cascade(CascadeMode.Stop)
                .Must(MinLengthofImage)
                .WithMessage(Message.MinImageLength)
                .Must(MaxLengthOfImage)
                .WithMessage(Message.MaxImageLength)
                .Must(IsImageType)
                .WithMessage(x => string.Format(Message.NotValidFile))
                .Must(IsUniqueImage)
                .WithMessage(x=>string.Format(Message.NotUniqueFiles));

        }
        

        private bool IsUniqueImage(IFormFile[] arg)
        {
            var g = arg.Count();
            var f = arg.Select(x => x.FileName).Distinct().Count();
            return arg.Length == arg.Select(x=>x.FileName).Distinct().Count();
        }

        private bool IsImageType(IFormFile[] arg)
        {
            return arg.All(x => x.ContentType.Contains("image"));
        }

        private bool MaxLengthOfImage(IFormFile[] arg)
        {
            return (arg.Length <=3) ? true : false;

        }

        private bool MinLengthofImage(IFormFile[] arg)
        {
            
            return (arg.Length > 0) ? true : false;
        }
       
    }
}
