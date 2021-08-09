using BookDonation.Domain.BookContext.Entities;
using BookDonation.Domain.UserContext.Enums;
using BookDonation.Domain.UserContext.ValueObjects;
using BookDonation.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookDonation.Domain.UserContext.Entities
{
    public class User : BaseEntity
    {
        private readonly IList<Book> _books;
        public User(Name name, Email email, Document document, BirthDate birth)
        {
            Name = name;
            Email = email;
            Document = document;
            Birth = birth;
            Type = EUserRole.Basic;
            _books = new List<Book>();
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public BirthDate Birth { get; private set; }
        public EUserRole Type { get; private set; }
        public IReadOnlyCollection<Book> Books => _books.ToArray();

        public void MakeAdmin()
        {
            Type = EUserRole.Admin;
        }

        public void Inactive()
        {
            Type = EUserRole.Inactive;
        }

        public void AddBook(string title, string author, string description, string year)
        {
            var item = new Book(title, author, description, year);
            _books.Add(item);
        }

        public void RemoveBook(Guid id)
        {
            var item = _books.FirstOrDefault(x => x.Id == id);
            if (item == null)
                AddNotification("Book", "Book not found");
            _books.Remove(item);
        }

        public void EditBook(Guid id, Book book)
        {
            var item = _books.FirstOrDefault(x => x.Id == id);
            if (item == null)
                AddNotification("Book", "Book not found");

            RemoveBook(id);
            AddBook(book.Title, book.Author, book.Description, book.DatePublished.ToString());

        }

        public void DonateBook(Guid id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                AddNotification("Book", "Book does not exists for donate");
            book.Donate();
        }

    }
}