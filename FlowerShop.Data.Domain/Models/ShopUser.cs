﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Data.Domain.Models
{
    public class ShopUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductItem> ProductsList { get; set; }
        public ShopUser() { }

        public ShopUser(string login, string email, string lastName, string firstName,string phoneNamber)
        {
            FirstName=firstName;
            LastName=lastName;
            Email=email;
            UserName = login;
            PhoneNumber=phoneNamber;

        }
    }
}
