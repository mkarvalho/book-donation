using BookDonation.Domain.UserContext.Entities;
using BookDonation.Domain.UserContext.Repositories;

namespace BookDonation.Tests.UserContext.Fakes
{
    public class FakeUserRepository : IUserRepository
    {
        public bool IsDocumentAvailable(string document)
        {
            return true;
        }

        public bool IsEmailAvailable(string email)
        {
            return true;
        }

        public void Save(User user)
        {
            
        }
    }
}
