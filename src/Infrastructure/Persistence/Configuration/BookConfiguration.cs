using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.WriteConfiguration
{
    public class BookWriteConfiguration :
        IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                bookId => bookId.Value,
                value => new BookId(value));

            builder.Property(c => c.Title).HasMaxLength(50);

            builder.Property(c => c.Description).HasMaxLength(500);

            builder.HasOne<Author>()
                .WithMany()
                .HasForeignKey("AuthorId");

        }
    }

}