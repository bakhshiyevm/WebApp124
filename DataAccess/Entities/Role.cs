using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public List<UserRoles> UserRoles { get; set; }
    }
}
