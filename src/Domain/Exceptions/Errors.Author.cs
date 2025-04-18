using ErrorOr;

namespace Domain.Exceptions
{
    public static partial class Errors
    {
        public static class Author
        {
            public static Error PhoneNumberWithBadFormat => Error.Validation("Author.PhoneNumber", "Phone number has not valid format.");
            public static Error AddressWithBadFormat => Error.Validation("Author.Address", "Address is not valid");
            public static Error NotFound => Error.Validation("Author.NotFound", "The Author with the provide id was not found.");
        }
    }
}