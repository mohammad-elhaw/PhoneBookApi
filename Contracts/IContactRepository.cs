using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IContactRepository
    {
        void CreateContact(Contact contact);
        void DeleteContact(Contact contact);
        Task<PageList<Contact>> GetAllContactsAsync(ContactParameters contactParameters,
            bool trackChanges);
        Task<Contact> GetContactAsync(Guid id, bool trackChanges);
    }
}
