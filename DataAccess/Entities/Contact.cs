using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Contact : BaseEntity
    {
        [Required]
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
