using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class RoomTypeRepository(TamDbContext context) : GenericRepository<RoomType>(context), IRoomTypeRepository
    {
        public  IQueryable<RoomType> GetAllRoomTypes()
        {
            return context.RoomTypes
                .OrderByDescending(r => r.DeletedAt == null)
                .ThenBy(r => r.Name);
        }
    }
}
