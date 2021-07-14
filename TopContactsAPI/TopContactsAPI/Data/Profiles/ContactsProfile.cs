using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopContactsAPI.Model;
using TopContactsAPI.V1.Dto;

namespace TopContactsAPI.Data.Profiles
{
    public class ContactsProfile : AutoMapper.Profile
    {
        public ContactsProfile()
        {
            CreateMap<Contact, ContactDto>();
        }
    }
}
