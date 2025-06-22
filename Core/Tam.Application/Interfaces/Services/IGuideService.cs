
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;

using Tam.Application.Dtos.Guide;

namespace Tam.Application.Interfaces.Services
{
    public interface IGuideService
    {
        Task<ServiceResult> CreateAsync(CreateGuideDto createGuideDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateGuideDto updateGuideDto);
        Task<ServiceResult> SoftDeleteGuideAsync(int id);

        Task<ServiceResult<PagedResult<ListGuideDto>>> GetAllAsync(int page, int pageSize);
        Task<ServiceResult<GuideDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult> AssignRegionsAsync(int guideId, List<int> regionIds);
        Task<ServiceResult> RemoveRegionsAsync(int guideId, int regionId);
        Task<ServiceResult> AssignLocationsAsync(int guideId, List<int> locationIds);
        Task<ServiceResult> RemoveLocationAsync(int guideId, int locationId);
        Task<ServiceResult> AssignLanguagesAsync(int guideId, List<int> languageIds);
        Task<ServiceResult> RemoveLanguageAsync(int guideId, int languageId);


        Task<ServiceResult<List<GuideSearchResultDto>>> SearchAsync(string searchTerm);
    }
}
