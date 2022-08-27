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
    public class UserService : BaseService<UserDTO,User, UserDTO>, IUserService
    {
        
        public UserService(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public List<UserContactsDTO> GetUserContacts() 
        {
            var res = _db.Users.Include(x => x.Contacts).ToList();

            var dto = _mapper.Map<List<User>, List<UserContactsDTO>>(res);
            
            return dto;
        }

        public UserDTO Login(string ps, string us)
        {
           
            var res = _db.Users.Where(x => x.Name == us && x.Password == ps);
            if (res.Count() == 1)
            {
                var dto  = _mapper.Map<User,UserDTO> (res.First());
                return dto;
            }
            else
            {
                throw new Exception("User tapilmadi");
            }

        }

        public IEnumerable<UserRoleDTO> GetUserRoles()
        {
            var ent = _dbSet.Include(x => x.Roles);

            var res = _mapper.Map<IEnumerable<UserRoleDTO>>(ent);

            return res;
        }
    }
}
