using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Models;

namespace Infrastructure.Persistence.ReadConfiguration
{
    internal sealed class AuthorReadConfiguration :
        IEntityTypeConfiguration<AuthorReadModel>
    {
        public void Configure(EntityTypeBuilder<AuthorReadModel> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Address)
                .HasConversion(
                    a => a.ToString(),
                    value => AddressReadModel.Create(value)
                );

            builder.Property(a => a.PhoneNumber)
                .HasConversion(
                    a => a.ToString(),
                    value => PhoneNumberReadModel.Create(value)
                );
        }
    }
}