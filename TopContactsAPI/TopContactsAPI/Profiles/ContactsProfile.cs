using TopContactsAPI.Model;
using TopContactsAPI.V1.Dto;

namespace TopContactsAPI.Profiles
{
    public class ContactsProfile : AutoMapper.Profile
    {
        public ContactsProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}