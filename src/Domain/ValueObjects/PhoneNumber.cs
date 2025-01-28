namespace Domain.ValueObjects
{
    public partial record PhoneNumber
    {
        private const int DefaultLenght = 12;
        private const string Pattern = @"^\+?52\s?(\d{2,3})\s?\d{4}\s?\d{4}$";

        private PhoneNumber(string value) => Value = value;

        public static PhoneNumber? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLenght)
            {
                return null;
            }

            return new PhoneNumber(value);
        }

        public string Value { get; init; }

        [GeneratedRegex(Pattern)]
        private static partial Regex PhoneNumberRegex();
    }
}