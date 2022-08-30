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
using Services.Helper;

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

        public UserDTO Login(UserDTO model)
        {
           
            var res = _db.Users.Where(x => x.Username == model.Username );

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();
                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
				{
                    throw new Exception("Wrong password!");
				}
            }
            else
            {
                throw new Exception("User not found");
            }

        }

		public override UserDTO Create(UserDTO model)
		{
            model.Salt = Crypto.GenerateSalt();
            model.PasswordHash = Crypto.GenerateSHA256Hash(model.Password, model.Salt);
			
            return base.Create(model);
		}

		public IEnumerable<UserRoleDTO> GetUserRoles()
        {
            var ent = _dbSet.Include(x => x.Roles);

            var res = _mapper.Map<IEnumerable<UserRoleDTO>>(ent);

            return res;
        }
    }
}
