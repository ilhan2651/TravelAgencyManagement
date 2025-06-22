using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.RoomType;

namespace Tam.Application.Interfaces.Services
{
    public interface IRoomTypeService
    {
        Task<ServiceResult> CreateAsync(CreateRoomTypeDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateRoomTypeDto dto);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult<List<ListRoomTypeDto>>> GetAllAsync();
    }
}
