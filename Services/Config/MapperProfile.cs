using AutoMapper;
using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>();

            CreateMap<User, UserContactsDTO>()
                .ForMember(x=>x.Contacts , y=>y.MapFrom(src=> src.Contacts));

            CreateMap<User, UserDTO>();


            CreateMap<ContactDTO, Contact>();

            CreateMap<Contact, ContactDTO>();


            CreateMap<RoleDTO, Role>();

            CreateMap<Role, RoleDTO>();


            CreateMap<UserRoleDTO, UserRoles>();
                

            CreateMap<UserRoles, UserRoleDTO>()
                 .ForMember(m => m.UserName, opt => opt.MapFrom(src => src.User.Name))
                 .ForMember(m => m.RoleName, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
