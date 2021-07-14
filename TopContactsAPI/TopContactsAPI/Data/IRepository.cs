using System;
using System.Threading.Tasks;
using TopContactsAPI.Model;

namespace TopContactsAPI.Data
{
    public interface IRepository
    {
        void Create<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();

        Profile GetProfileById(Guid id);

        Contact[] GetAllContacts();

        Task<Contact[]> GetAllContactsByProfileIdAsync(Guid id);
    }
}
