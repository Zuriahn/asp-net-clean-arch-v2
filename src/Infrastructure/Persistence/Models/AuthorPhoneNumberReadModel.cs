using System.Text.RegularExpressions;

namespace Infrastructure.Persistence.Models
{
    internal class PhoneNumberReadModel
    {

        private PhoneNumberReadModel(string value) => Value = value;

        public static PhoneNumberReadModel? Create(string value)
        {
            return new PhoneNumberReadModel(value);
        }

        public string Value { get; init; }
    }
}