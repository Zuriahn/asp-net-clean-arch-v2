
namespace Infrastructure.Persistence.Models
{
    internal class AddressReadModel
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string Street {get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }

        public static AddressReadModel Create(string value)
        {
            var splitAddress = value.Split(",");
            return new AddressReadModel
            {
                Country = splitAddress[0],
                State = splitAddress[1],
                Street = splitAddress[2],
                Number = int.Parse(splitAddress[3]),
                Zipcode = splitAddress[4]
            };
        }

        public override string ToString() => $"{Country}, {State}, {Street}, {Number}, {Zipcode}";
    }
}