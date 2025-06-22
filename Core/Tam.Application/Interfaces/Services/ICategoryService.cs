using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.CategoryDtos;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.CustomerDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<ServiceResult> CreateCategoryAsync(CreateCategoryDto createDto);
        Task<ServiceResult> SoftDeleteCategoryAsync(int categoryId);
        Task<ServiceResult> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateDto);
        Task<ServiceResult<CategoryDetailDto>> GetCategoryByIdAsync(int categoryId);
        Task<ServiceResult<List<CategoryListDto>>> GetAllCategories();
    }
}
