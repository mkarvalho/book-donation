using BookDonation.Domain.UserContext.Commands.UserCommands.Inputs;
using BookDonation.Domain.UserContext.Commands.UserCommands.Outputs;
using BookDonation.Domain.UserContext.Entities;
using BookDonation.Domain.UserContext.Repositories;
using BookDonation.Domain.UserContext.ValueObjects;
using BookDonation.Shared.Commands;
using Flunt.Notifications;

namespace BookDonation.Domain.UserContext.Handlers
{
    public class UserHandler : 
        Notifiable<Notification>, 
        ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            //Verificar se existe documento
            if (_repository.IsDocumentAvailable(command.Document))
                AddNotification("Document", "Document already exists");

            //Verificar se existe o email
            if (_repository.IsEmailAvailable(command.Email))
                AddNotification("Email", "Email already exists");


            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var birthDate = new BirthDate(command.BirthDate);

            //Criar a entidade
            var user = new User(name, email, document, birthDate);

            //Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(birthDate.Notifications);
            AddNotifications(user.Notifications);

            if (IsValid)
                return new CreateUserCommandResult(
                    false,
                    "Correct the fields below",
                    Notifications);

            //Persistir o user
            _repository.Save(user);

            //Retorar o resultado
            return new CreateUserCommandResult(true,
                "User created",
                new {
                    user.Id,
                    Name = user.Name.ToString(),
                    Document = user.Document.ToString(),
                    Email = user.Email.ToString(),
                    Birth = user.Birth.ToString()
                }
            );
        }
    }
}
