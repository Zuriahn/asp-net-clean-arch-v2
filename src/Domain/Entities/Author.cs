using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Author : AggregateRoot
    {
        public Author(AuthorId id, string name, Address address, PhoneNumber phoneNumber)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public Author()
        {
            
        }

        public AuthorId Id { get; private set; }

        public string Name { get; private set; }

        public Address Address { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public static Author UpdateAuthor(Guid id, string name, Address address, PhoneNumber phoneNumber)
        {
            return new Author(new AuthorId(id), name, address, phoneNumber);
        }
    }

}