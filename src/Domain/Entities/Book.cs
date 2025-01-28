using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Book : AggregateRoot
    {
        public Book(BookId id, string title, string description, int pages)
        {
            Id = id;
            Title = title;
            Description = description;
            Pages = pages;
        }

        public Book()
        {
            
        }

        public BookId Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int Pages { get; private set; }
        public static Book UpdateBook(Guid id, string title, string description, int pages)
        {
            return new Book(new BookId(id), title, description, pages);
        }
    }

}