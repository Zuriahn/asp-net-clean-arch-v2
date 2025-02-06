
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class User : AggregateRoot
    {
        public User(UserId id, string name, string lastName, Email email, Password password)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public User()
        {

        }

        public UserId Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }

        public Password Password { get; private set; }
        public Email Email { get; private set; }

    }
}