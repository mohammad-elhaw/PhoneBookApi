using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace PhoneBook
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactForCreationDto, Contact>();
            CreateMap<ContactForUpdateDto, Contact>();
        }
    }
}
