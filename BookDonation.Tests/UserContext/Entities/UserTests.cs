using BookDonation.Domain.UserContext.Entities;
using BookDonation.Domain.UserContext.ValueObjects;
using Xunit;

namespace BookDonation.Tests.UserContext.Entities
{
    public class UserTests
    {
        [Fact]
        public void Should_return_a_valid_user()
        {
            var name = new Name("first_name", "");
            var email = new Email("email@email.com");
            var document = new Document("68334798016");
            var birth = new BirthDate("27/10/1969");
            var user = new User(name, email, document, birth);

            Assert.True(user.IsValid);
        }
    }
}
