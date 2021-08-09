using BookDonation.Domain.UserContext.Entities;
using BookDonation.Shared.ValueObjects;
using Flunt.Validations;

namespace BookDonation.Domain.UserContext.ValueObjects
{
    public class Name : BaseValueObjects
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .IsNotNullOrWhiteSpace(FirstName, "FirstName", "Nome não pode ser vazio")
                .IsNotNullOrWhiteSpace(LastName, "LastName", "Sobrenome não pode ser vazio")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}