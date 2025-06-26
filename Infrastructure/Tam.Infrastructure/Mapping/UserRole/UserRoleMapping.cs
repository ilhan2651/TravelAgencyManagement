using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.UserRole;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Infrastructure.Mapping
{
    public class UserRoleMapping : Profile
    {
        public UserRoleMapping()
        {
            CreateMap<AssignUserRoleDto,UserRole>();
            CreateMap<UserRole, UserRoleListDto>();
        }
    }
}
