using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ContactNotFoundException : NotFoundException
    {
        public ContactNotFoundException(Guid id)
            : base($"The contact with {id} doesn't exist in database")
        {
            
        }
    }
}
