using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopContactsAPI.Model
{
    public class Profile
    {
        public Profile()
        {

        }

        public Profile(Guid id,
                       string name,
                       string email,
                       string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
