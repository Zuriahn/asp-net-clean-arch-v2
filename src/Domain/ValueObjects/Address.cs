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

        public static Address? Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            var splitAddress = value.Split(",");
            return new Address(splitAddress[0], splitAddress[1], splitAddress[2], int.Parse(splitAddress[3]), splitAddress[4]);
        }

        public override string ToString() => $"{Country}, {State}, {Street}, {Number}, {Zipcode}";
    }
}