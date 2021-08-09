using BookDonation.Domain.UserContext.Entities;

namespace BookDonation.Domain.UserContext.Repositories
{
    public interface IUserRepository
    {
        bool IsDocumentAvailable(string document);
        bool IsEmailAvailable(string email);
        void Save(User user);
    }
}
