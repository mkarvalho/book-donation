using BookDonation.Domain.BookContext.Entities.Contracts;
using BookDonation.Domain.BookContext.Enums;
using BookDonation.Shared.Entities;
using BookDonation.Shared.Utils;
using System;

namespace BookDonation.Domain.BookContext.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string description, string date)
        {
            
            Title = title;
            Author = author;
            Description = description;
            DatePublished = StringToDate.ConvertToDate(date);
            Status = EBookStatus.Available;

            AddNotifications(new CreateBookContract(this));

        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }
        public DateTime DatePublished { get; private set; }
        public EBookStatus Status { get; private set; }

        public void Donate()
        {
            Status = EBookStatus.Donated;
        }

        public override string ToString()
        {
            return $"{Title} por {Author} edição de {DatePublished.Year}";
        }
    }
}
