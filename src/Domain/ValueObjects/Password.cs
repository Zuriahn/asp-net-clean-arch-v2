namespace Domain.ValueObjects
{
    public partial record Password
    {

        public static explicit operator string(Password password) => password.Value;        
        private const int DefaultLenght = 8;
        private const string Pattern = @"^(?=.*[A-Z])(?=.*[\W_]).{8,}$";

        private Password(string value) => Value = value;

        public static Password? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !PasswordRegex().IsMatch(value) || value.Length != DefaultLenght)
            {
                return null;
            }

            return new Password(value);
        }

        public string Value { get; init; }

        [GeneratedRegex(Pattern)]
        private static partial Regex PasswordRegex();
    }
}