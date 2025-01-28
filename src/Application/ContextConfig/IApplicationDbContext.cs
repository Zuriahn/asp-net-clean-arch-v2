using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}