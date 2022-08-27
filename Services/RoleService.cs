using Services.Abstract;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class RoleService : BaseService<RoleDTO,Role, RoleDTO>, IRoleService
    {
        public RoleService(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

    }
}
