using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IContactService> _contactService;

        public ServiceManager(IRepositoryManager repsitoryManager, IMapper mapper)
        {
            _contactService = new Lazy<IContactService>(new ContactService(repsitoryManager, mapper));
        }
        public IContactService ContactService => _contactService.Value;
    }
}
