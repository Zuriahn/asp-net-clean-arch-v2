using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Book : AggregateRoot
    {
        public Book(BookId id, string title, string description, int pages, AuthorId authorId)
        {
            Id = id;
            Title = title;
            Description = description;
            Pages = pages;
            AuthorId = authorId;
        }

        public Book()
        {

        }

        public BookId Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int Pages { get; private set; }
        public AuthorId AuthorId { get; private set; }
        public static Book UpdateBook(Guid id, string title, string description, int pages, AuthorId authorId)
        {
            return new Book(new BookId(id), title, description, pages, authorId);
        }
    }

}