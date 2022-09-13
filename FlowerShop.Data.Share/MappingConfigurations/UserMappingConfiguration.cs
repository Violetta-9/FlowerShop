

using FlowerShop.Data.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.Data.Share.MappingConfigurations
{
    public class UserMappingConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasColumnName(nameof(User.FirstName)).HasMaxLength(256)
                .IsRequired();
            builder.Property(x => x.LastName).HasColumnName(nameof(User.LastName)).HasMaxLength(256)
                .IsRequired();
        }
    }
}
