using BookDonation.Domain.UserContext.ValueObjects;
using Xunit;

namespace BookDonation.Tests.UserContext.ValueObjects
{
    public class UserTests
    {

        [Theory]
        [InlineData("01/01/1990", true)]
        [InlineData("01/01/2050", false)]
        public void Should_return_a_valid_birthdate(string date, bool expectedResult)
        {
            var birth = new BirthDate(date);

            Assert.Equal(expectedResult, birth.IsValid);
        }
    }
}
