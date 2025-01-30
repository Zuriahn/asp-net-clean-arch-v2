using ErrorOr;

namespace Domain.Exceptions
{
    public static partial class Errors
    {
        public static class Book
        {
            public static Error BookWithNoTitle => Error.Validation("Book.Title", "Book can not be empty.");
        }
    }
}