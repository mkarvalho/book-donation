using Flunt.Validations;

namespace BookDonation.Domain.BookContext.Entities.Contracts
{
    public class CreateBookContract : Contract<Book>
    {
        public CreateBookContract(Book book)
        {
            var date = book.DatePublished.Date.Year.ToString();
            Requires()
                .IsNotNullOrWhiteSpace(book.Title, "Title", "Invalid Title")
                .IsNotNullOrWhiteSpace(book.Description, "Description", "Invalid Description")
                .IsNotNullOrWhiteSpace(book.Author, "Year", "Invalid Author")
                .IsNotNullOrWhiteSpace(date, "Year", "Invalid year");
        }
    }
}
