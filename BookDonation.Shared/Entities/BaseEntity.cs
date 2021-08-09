using Flunt.Notifications;
using System;

namespace BookDonation.Shared.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}