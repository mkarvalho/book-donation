using BookDonation.Domain.BookContext.Entities;
using Xunit;

namespace BookDonation.Tests.BookContext
{
    public class BookTests
    {
        [Fact]
        public void Should_return_a_valid_book()
        {
            var book = new Book("book_title", "book_author", "book_description", "02/11/1987");

            Assert.True(book.IsValid);
        }
    }
}
