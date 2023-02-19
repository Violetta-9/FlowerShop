using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.Product;
using FlowerShop.Application.Resources;
using FlowerShop.Data.Share.DbContext;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Application.Validators.Commands.Product.AddProduct
{
    public  class AddProductValidator:AbstractValidator<AddProductCommand>
    {
        private readonly FlowerShopDbContext _db;
       
        public AddProductValidator(FlowerShopDbContext db)
        {
            _db= db;
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
                .WithMessage(x => string.Format(Message.NotUniqueFiles));
            RuleFor(x => x.Product.Title)
                .Must(HasUniqTitle)
                .WithMessage(Message.ProductExsict);


        }

        private bool HasUniqTitle(string title)
        {
            return !_db.Products.Any(x => x.Title.ToLower() == title.ToLower());
        }

        private bool IsUniqueImage(IFormFileCollection arg)
        {
            var g = arg.Count();
            var f = arg.Select(x => x.FileName).Distinct().Count();
            return arg.Count == arg.Select(x=>x.FileName).Distinct().Count();
        }

        private bool IsImageType(IFormFileCollection arg)
        {
            return arg.All(x => x.ContentType.Contains("image"));
        }

        private bool MaxLengthOfImage(IFormFileCollection arg)
        {
            return (arg.Count <=3) ? true : false;

        }

        private bool MinLengthofImage(IFormFileCollection arg)
        {

            return arg.Any();
        }
       
    }
}
