using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IContactService
    {
        Task<(IEnumerable<ContactDto> contacts, MetaData metaData)> GetAllContactsAsync(
            ContactParameters contactParameters, bool trackChanges);
        Task<ContactDto> GetContactAsync(Guid id, bool trackChanges);
        Task<ContactDto> CreateContactAsync(ContactForCreationDto contact);
        Task DeleteContactAsync(Guid id, bool trackChanges);
        Task UpdateContactAsync(Guid id, ContactForUpdateDto contactForUpdate, bool trackChanges);
    }
}
