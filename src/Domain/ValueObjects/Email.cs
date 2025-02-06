namespace Domain.ValueObjects
{
    public partial record Email
    {
        public static explicit operator string(Email email) => email.Value;
        private const string Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        private Email(string value) => Value = value;

        public static Email? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !EmailRegex().IsMatch(value))
            {
                return null;
            }

            return new Email(value);
        }

        public string Value { get; init; }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}