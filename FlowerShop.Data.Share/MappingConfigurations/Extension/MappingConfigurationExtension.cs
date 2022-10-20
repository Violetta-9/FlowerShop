using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.Data.Share.MappingConfigurations.Exstension
{
    public static class MappingConfigurationExtension
    {
        public static void MapKeyPrimary<TEntityType>(this EntityTypeBuilder<TEntityType> builder) where TEntityType : class, IIdentifiable<long>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

        }
    }
}
