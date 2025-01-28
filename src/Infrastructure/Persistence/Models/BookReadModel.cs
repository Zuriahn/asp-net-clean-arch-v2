
namespace Infrastructure.Persistence.Models
{
    internal class BookReadModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }

        public AuthorReadModel Author { get; set; }
    }
}