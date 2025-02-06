using ErrorOr;

namespace Domain.Exceptions
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error EmailIsNotValid => Error.Validation("Book.Email", "Email is not valid.");
            public static Error PasswordIsNotValid => Error.Validation("Book.Password", "Password is not valid.");
        }
    }
}