using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Role> Roles { get; set; }

    }
}
