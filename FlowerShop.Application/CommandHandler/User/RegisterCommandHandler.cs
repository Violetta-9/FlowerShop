using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Command.User;
using FlowerShop.Application.Configurations.User;
using FlowerShop.Application.Contracts.Outgoing;
using FlowerShop.Data.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace FlowerShop.Application.CommandHandler.User
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ShopUser> _userManager;
        public RegisterCommandHandler(RoleManager<IdentityRole> roleManager, UserManager<ShopUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var roleName = UserRole.User;
            var user = new ShopUser(request.NewUser.Login, request.NewUser.Email, request.NewUser.LastName,
                request.NewUser.FirstName, request.NewUser.PhoneNumber);
            var createUser =await _userManager.CreateAsync(user,request.NewUser.Password);
            if (!createUser.Succeeded)
            {
                //todo:
            }

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
            await _userManager.AddToRoleAsync(user,roleName);
            await _userManager.UpdateAsync(user);
            return Response.Success;
        }
    }
}
