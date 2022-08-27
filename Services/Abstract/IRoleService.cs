using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IRoleService : IBaseService<RoleDTO, Role, RoleDTO>
    {
    }
}
