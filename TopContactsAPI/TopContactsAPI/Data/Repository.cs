using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TopContactsAPI.Model;

namespace TopContactsAPI.Data
{
    public class Repository : IRepository
    {
        private readonly ContactsContext _context;

        public Repository(ContactsContext context)
        {
            _context = context;
        }

        public void Create<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Profile GetProfileById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Contact[] GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Task<Contact[]> GetAllContactsByProfileIdAsync(Guid id)
        {
            IQueryable<Contact> query = _context.Contacts;

            query = query
                        .AsNoTracking()
                        .OrderBy(c => c.Id)
                        .Where(contact => contact.ProfileId == id);

            return query.ToArrayAsync();
        }

        public Contact GetContactById(Guid contactId)
        {
            IQueryable<Contact> query = _context.Contacts;

            query = query.AsNoTracking().OrderBy(c => c.Id).Where(contact => contact.Id == contactId);

            return query.FirstOrDefault();
        }
    }
}