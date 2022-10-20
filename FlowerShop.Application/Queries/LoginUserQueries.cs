using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Application.Contracts.Incoming.User;
using FlowerShop.Application.Contracts.Outgoing;
using MediatR;

namespace FlowerShop.Application.Queries
{
    public  class LoginUserQueries:IRequest<string>
    {
        public LoginDTO User { get; set; }
        public LoginUserQueries(LoginDTO user)
        {
            User = user;
        }
    }
}
