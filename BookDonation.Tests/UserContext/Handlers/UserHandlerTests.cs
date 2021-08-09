using BookDonation.Domain.UserContext.Commands.UserCommands.Inputs;
using BookDonation.Domain.UserContext.Handlers;
using BookDonation.Tests.UserContext.Fakes;
using Xunit;

namespace BookDonation.Tests.UserContext.Handlers
{
    public class UserHandlerTests
    {
        [Fact]
        public void Should_create_user_when_command_is_valid()
        {
            var command = new CreateUserCommand
            {
                FirstName = "first_name",
                LastName = "last_name",
                Document = "68334798016",
                BirthDate = "27/10/1969",
                Email = "email@email.com"
            };

            var handler = new UserHandler(new FakeUserRepository());

            var result = handler.Handle(command);

            Assert.True(result.Success);
        }
    }
}
