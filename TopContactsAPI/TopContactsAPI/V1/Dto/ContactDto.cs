using System;

namespace TopContactsAPI.V1.Dto
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Favorite { get; set; }
        public Guid ProfileId { get; set; }
    }
}
