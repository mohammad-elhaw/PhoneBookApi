using Microsoft.AspNetCore.Mvc;
using PhoneBook.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace PhoneBook.Presentation.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ContactsController(IServiceManager service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _service.ContactService.GetAllContactsAsync(trackChanges: false);
            return Ok(contacts);
        }

        [HttpGet("{id:guid}", Name = "ContactById")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var contact = await _service.ContactService.GetContactAsync(id, trackChanges: false);
            return Ok(contact);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateContact([FromBody] ContactForCreationDto contact)
        {
            var createdContact = await _service.ContactService.CreateContactAsync(contact);
            return CreatedAtRoute("ContactById", new { id = createdContact.Id }, createdContact);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            await _service.ContactService.DeleteContactAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateContact(
            [FromBody] ContactForUpdateDto contact, Guid id)
        {
            await _service.ContactService.UpdateContactAsync(id, contact, trackChanges: true);
            return NoContent();
        }

    }
}
