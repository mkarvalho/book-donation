using BookDonation.Shared.ValueObjects;
using Flunt.Validations;

namespace BookDonation.Domain.UserContext.ValueObjects
{
    public class Email : BaseValueObjects
    {
        public Email(string emailAdress)
        {
            EmailAdress = emailAdress;

            AddNotifications(
                new Contract<Email>()
                    .IsEmail(EmailAdress, "Email", "Email inválido")
            );
        }

        public string EmailAdress { get; private set; }

        public override string ToString()
        {
            return $"{EmailAdress}";
        }
    }
}