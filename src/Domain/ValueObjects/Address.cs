namespace Domain.ValueObjects
{
    public partial record Address
    {
        public Address(string country, string state, string street, int number, string zipcode)
        {
            Country = country;
            State = state;
            Street = street;
            Number = number;
            Zipcode = zipcode;
        }

        public string Country { get; init; }
        public string State { get; init; }
        public string Street { get; init; }
        public int Number { get; init; }
        public string Zipcode { get; init; }

        public static Address? Create(string country, string state, string street, int number, string zipcode)
        {
            if (
            string.IsNullOrWhiteSpace(country)
            ||
            string.IsNullOrWhiteSpace(state)
            ||
            string.IsNullOrWhiteSpace(street)
            ||
            number <= 0
            || string.IsNullOrWhiteSpace(zipcode))
            {
                return null;
            }
            return new Address(country, state, street, number, zipcode);
        }

        public override string ToString() => $"{Country}, {State}, {Street}, {Number}, {Zipcode}";
    }
}