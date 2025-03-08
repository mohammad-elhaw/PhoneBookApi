using Microsoft.AspNetCore.Mvc;
using PhoneBook.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

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
        public async Task<IActionResult> GetContacts([FromQuery] ContactParameters contactParameters)
        {
            var pageResult = await _service.ContactService.GetAllContactsAsync(
                contactParameters, trackChanges: false);
            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(pageResult.metaData);

            return Ok(pageResult.contacts);
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
