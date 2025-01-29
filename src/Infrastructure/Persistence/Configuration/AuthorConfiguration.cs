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

            builder.OwnsOne(a => a.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(3)
                    .HasColumnName("Country");

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(20)
                    .HasColumnName("State");

                addressBuilder.Property(a => a.Street)
                    .HasMaxLength(20)
                    .IsRequired(false)
                    .HasColumnName("Street");

                addressBuilder.Property(a => a.Number)
                    .HasColumnName("Number");

                addressBuilder.Property(a => a.Zipcode)
                    .HasMaxLength(10)
                    .IsRequired(false)
                    .HasColumnName("Zipcode");
            });

        }
    }

}