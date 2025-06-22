using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.HotelRoomOptionDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IHotelRoomOptionService
    {
        Task<ServiceResult> CreateAsync(CreateHotelRoomOptionDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateHotelRoomOptionDto dto);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<ListHotelRoomOptionDto>>> GetAllAsync();
        Task<ServiceResult<ListHotelRoomOptionDto>> GetByIdAsync(int id);
    }

}
