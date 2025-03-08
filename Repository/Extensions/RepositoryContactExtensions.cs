using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryContactExtensions
    {
        public static IQueryable<Contact> Search(this IQueryable<Contact> contacts,
            string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return contacts;

            return contacts.Where(c =>
                c.Name.Contains(searchTerm) ||
                c.Email.Contains(searchTerm) ||
                c.PhoneNumber.Contains(searchTerm));
        }
    }
}
