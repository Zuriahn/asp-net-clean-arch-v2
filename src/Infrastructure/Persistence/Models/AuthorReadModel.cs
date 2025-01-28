using Infrastructure.Persistence.Models;

using Domain.ValueObjects;

namespace Infrastructure.Persistence.Models
{
    internal class AuthorReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressReadModel Address { get; set; }
        public PhoneNumberReadModel PhoneNumber { get; set; }
        public ICollection<BookReadModel> Books { get; set; }
    }
}