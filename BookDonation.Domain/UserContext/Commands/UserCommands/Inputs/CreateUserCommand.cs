using Flunt.Notifications;
using Flunt.Validations;
using Flunt.Extensions.Br.Validations;
using BookDonation.Shared.Commands;

namespace BookDonation.Domain.UserContext.Commands.UserCommands.Inputs
{
    public class CreateUserCommand : Notifiable<Notification>, ICommand
    {
        public CreateUserCommand()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }

        public bool Valid()
        {
            AddNotifications(new Contract<CreateUserCommand>()
                    .IsNotNullOrWhiteSpace(FirstName, "FirstName", "FirstName Invalid")
                    .IsNotNullOrWhiteSpace(LastName, "LastName", "LastName Invalid")
                    .IsCpf(Document, "Document", "Document Invalid")
                    .IsEmail(Email, "Email", "Email Invalid")
                    .IsNotNullOrEmpty(BirthDate, "BirthDate", "BirthDate Invalid")
                    );
            return IsValid;
        }
    }
}
