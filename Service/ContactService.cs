using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ContactService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ContactDto> CreateContactAsync(ContactForCreationDto contact)
        {
            var contactEntity = _mapper.Map<Contact>(contact);
            _repository.Contact.CreateContact(contactEntity);
            await _repository.SaveAsync();
            var contactToReturn = _mapper.Map<ContactDto>(contactEntity);
            return contactToReturn;
        }

        public async Task DeleteContactAsync(Guid id, bool trackChanges)
        {
            var contactEntity = await _repository.Contact.GetContactAsync(id, trackChanges);
            if (contactEntity is null)
                throw new ContactNotFoundException(id);
            _repository.Contact.DeleteContact(contactEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateContactAsync(Guid id, ContactForUpdateDto contactForUpdate, bool trackChanges)
        {
            var contactEntity = await _repository.Contact.GetContactAsync(id, trackChanges);
            if (contactEntity is null)
                throw new ContactNotFoundException(id);

            _mapper.Map(contactForUpdate, contactEntity);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync(bool trackChanges)
        {
            var contacts = await _repository.Contact.GetAllContactsAsync(trackChanges);
            var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return contactsDto;
        }

        public async Task<ContactDto> GetContactAsync(Guid id, bool trackChanges)
        {
            var contactDb = await _repository.Contact.GetContactAsync(id, trackChanges);
            if (contactDb is null) throw new ContactNotFoundException(id);

            var contactDto = _mapper.Map<ContactDto>(contactDb);
            return contactDto;
        }
    }
}
