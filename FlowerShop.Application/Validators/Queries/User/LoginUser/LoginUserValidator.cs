using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Queries;
using FlowerShop.Application.Resources;
using FlowerShop.Data.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.Application.Validators.Queries.User.LoginUser
{
    public class LoginUserValidator:AbstractValidator<LoginUserQueries>
    {
        public readonly UserManager<ShopUser> _userManager;
        public LoginUserValidator(UserManager<ShopUser> userManager)
        {
            _userManager = userManager;
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(x => x.User.UserLoginOrEmail)
                .Cascade(CascadeMode.Stop)
                .MustAsync(ExistsAsync)
                .WithMessage(x => string.Format(Message.UserNotFound, x.User.UserLoginOrEmail));
        }

        private async Task<bool> ExistsAsync(string arg, CancellationToken cancellation)
        {
            var existsUser=await _userManager.FindByNameAsync(arg);
            return existsUser != null;
        }
    }
}
