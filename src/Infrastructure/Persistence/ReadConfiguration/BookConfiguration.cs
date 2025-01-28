using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Models;

namespace Infrastructure.Config
{
    internal sealed class BookReadConfiguration :
        IEntityTypeConfiguration<BookReadModel>
    {
        public void Configure(EntityTypeBuilder<BookReadModel> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books);
        }
    }
}