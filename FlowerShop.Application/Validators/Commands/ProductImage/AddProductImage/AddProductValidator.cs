using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.ProductImage;
using FlowerShop.Application.Resources;
using FlowerShop.Data.Share.DbContext;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Application.Validators.Commands.ProductImage.AddProductImage
{
    public class AddProductValidator:AbstractValidator<AddProductImageCommand>
    {
        private readonly FlowerShopDbContext _db;

        public AddProductValidator(FlowerShopDbContext db)
        {
            _db = db;
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .Must(IsExsistProduct)
                .WithMessage(Message.DoNotExsistProduct);
            RuleFor(x => x)
                .Cascade(CascadeMode.Stop)
                .Must(CorectQuentityOfImage)
                .WithMessage(Message.MaxImageLength)
                .MustAsync(IsUniqueImageAsync)
                .WithMessage(x => string.Format(Message.NotUniqueFiles)); ;
            RuleFor(x => x.Images)
                .Cascade(CascadeMode.Stop)
                .Must(IsImageType)
                .WithMessage(x => string.Format(Message.NotValidFile));



        }

        private bool CorectQuentityOfImage(AddProductImageCommand productImage)
        {
            var countOfProductImageInDB = _db.ProductImages.Count(x => x.ProductId == productImage.ProductId);
            var count = productImage.Images.Length;
            return (countOfProductImageInDB +
                count <= 3);

        }

        private bool IsExsistProduct(long arg)
        {
            return _db.Products.Any(x => x.Id == arg);
        }
        private async Task<bool> IsUniqueImageAsync(AddProductImageCommand arg,CancellationToken cancellationToken)
        {
            var newImages = arg.Images.Select(x=>x.FileName);
            var imagesFromDb = _db.ProductImages.Where(x => x.ProductId == arg.ProductId).Select(x => x.FileName);
            var f = newImages.Distinct().Count();
          
            return await imagesFromDb.AllAsync(x => !newImages.Contains(x),cancellationToken:cancellationToken) &&
                   newImages.Count()==newImages.Distinct().Count();
            
        }

        private bool IsImageType(IFormFile[] arg)
        {
            return arg.All(x => x.ContentType.Contains("image"));
        }
    }
}
