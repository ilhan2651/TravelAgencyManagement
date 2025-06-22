using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IHotelRoomOptionRepository : IGenericRepository<HotelRoomOption>
    {
        IQueryable<HotelRoomOption> GetAllOptions();
        Task<HotelRoomOption> GetOptionByIdAsync(int id);
    }
}
