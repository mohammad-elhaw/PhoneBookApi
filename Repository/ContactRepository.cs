using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            
        }

        public void CreateContact(Contact contact) => Create(contact);

        public void DeleteContact(Contact contact) => Delete(contact);

        public async Task<PageList<Contact>> GetAllContactsAsync(ContactParameters contactParameters, 
            bool trackChanges)
        {
            var contacts = await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .Search(contactParameters.SearchTerm)
                .Skip((contactParameters.PageNumber - 1) * contactParameters.PageSize)
                .Take(contactParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PageList<Contact>(contacts, count, contactParameters.PageNumber,
                contactParameters.PageSize);
        }

        public async Task<Contact> GetContactAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }
}
