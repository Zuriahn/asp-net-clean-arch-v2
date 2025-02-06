using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.WriteConfiguration
{
    public class UserWriteConfiguration :
        IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasConversion(
                userId => userId.Value,
                value => new UserId(value));

            builder.Property(u => u.Email).HasConversion(
                email => email.Value,
                value => Email.Create(value)!
            );
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Password).HasConversion(
                password => password.Value,
                value => Password.Create(value)!
);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
        }
    }

}