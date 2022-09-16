

using FlowerShop.Data.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.Data.Share.MappingConfigurations
{
    public class UserMappingConfiguration : IEntityTypeConfiguration<ShopUser>
    {
        public void Configure(EntityTypeBuilder<ShopUser> builder)
        {
            builder.Property(x => x.FirstName).HasColumnName(nameof(ShopUser.FirstName)).HasMaxLength(256)
                .IsRequired();
            builder.Property(x => x.LastName).HasColumnName(nameof(ShopUser.LastName)).HasMaxLength(256)
                .IsRequired();
        }
    }
}
