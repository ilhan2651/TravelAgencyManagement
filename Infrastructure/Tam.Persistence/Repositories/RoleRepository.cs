﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class RoleRepository(TamDbContext context) : GenericRepository<Role>(context) , IRoleRepository 

    {
    }
}
