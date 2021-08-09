using BookDonation.Domain.UserContext.Commands.UserCommands.Inputs;
using Xunit;

namespace BookDonation.Tests.UserContext.Commands
{
    public class CreateUserCommandTests
    {
        [Fact]
        public void Should_return_a_valid_CreateUserCommand()
        {
            var command = new CreateUserCommand
            {
                FirstName = "first_name",
                LastName = "last_name",
                Document = "68334798016",
                BirthDate = "27/10/1969",
                Email = "email@email.com"
            };

            Assert.True(command.IsValid);
            Assert.Equal(0, command.Notifications.Count);
        }
    }
}
