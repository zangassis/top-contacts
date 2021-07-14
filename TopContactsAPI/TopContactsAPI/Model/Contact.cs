using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopContactsAPI.Model
{
    public class Contact
    {
        public Contact()
        {   

        }

        public Contact(Guid id,
                       string name,
                       string lastName,
                       string email,
                       string phone,
                       bool favorite,
                       Guid profileId)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Favorite = favorite;
            this.ProfileId = profileId;
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Favorite { get; set; }

        [ForeignKey("FK_Profile")]
        public Guid ProfileId { get; set; }

        public void ResetId()
        {
            this.Id = Guid.NewGuid();
        }

    }
}