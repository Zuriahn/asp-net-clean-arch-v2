using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.WriteConfiguration
{
    public class AuthorWriteConfiguration :
        IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                authorId => authorId.Value,
                value => new AuthorId(value));

            builder.Property(c => c.Name).HasMaxLength(50);

            builder.Property(c => c.PhoneNumber).HasConversion(
                phoneNumber => phoneNumber.Value,
                value => PhoneNumber.Create(value)!)
                .HasMaxLength(13);

            builder.Property(c => c.Address).HasConversion(
                address => address.ToString(),
                value => Address.Create(value)!)
                .HasMaxLength(100);

        }
    }

}