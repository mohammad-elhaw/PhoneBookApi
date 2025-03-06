using Entities.Models;

namespace Contracts
{
    public interface IContactRepository
    {
        void CreateContact(Contact contact);
        void DeleteContact(Contact contact);
        Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges);
        Task<Contact> GetContactAsync(Guid id, bool trackChanges);
    }
}
