using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Language;

namespace Tam.Application.Interfaces.Services
{
    public interface ILanguageService
    {
        Task<ServiceResult> CreateAsync(CreateLanguageDto createDto);
        Task<ServiceResult<LanguageListDto>> GetByIdAsync(int id);
        Task<ServiceResult<List<LanguageListDto>>> GetAllAsync();
        Task<ServiceResult> UpdateAsync(int id, UpdateLanguageDto updateDto);
        Task<ServiceResult> SoftDeleteAsync(int id);
    }
}