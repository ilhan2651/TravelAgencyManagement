using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.CategoryDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class CategoryService(ICategoryRepository categoryRepository,IMapper mapper, IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<ServiceResult> CreateCategoryAsync(CreateCategoryDto createDto)
        {
          var category = mapper.Map<Category>(createDto);
            category.CreatedAt = DateTime.UtcNow;
            await categoryRepository.AddAsync(category);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Kategori başarıyla oluşturuldu");
        }

        public async Task<ServiceResult<List<CategoryListDto>>> GetAllCategories()
        {
            var categories =await  categoryRepository.GetAllCategories();
            if(categories== null || !categories.Any())
            {
                return ServiceResult<List<CategoryListDto>>.Fail("Hiçbir kategori bulunamadı.");
            }
            var result = mapper.Map<List<CategoryListDto>>(categories);
            return ServiceResult<List<CategoryListDto>>.Ok(result);
        }

        public async Task<ServiceResult<CategoryDetailDto>> GetCategoryByIdAsync(int categoryId)
        {
            var category = await categoryRepository.GetByIdAsync(categoryId);
            if(category==null)
                return ServiceResult<CategoryDetailDto>.Fail("Kategori bulunamadı.");
            var categoryDetailDto = mapper.Map<CategoryDetailDto>(category);
            return ServiceResult<CategoryDetailDto>.Ok(categoryDetailDto);
        }

        public async Task<ServiceResult> SoftDeleteCategoryAsync(int categoryId)
        {
           var category = await categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
                return ServiceResult.Fail("Kategori bulunamadı.");
            if (category.DeletedAt != null)
                return ServiceResult.Fail("Kategori zaten silinmiş.");
            category.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Kategori başarıyla silindi.");
        }

        public async Task<ServiceResult> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateDto)
        {
            var category = await categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
                return ServiceResult.Fail("Kategori bulunamadı.");
            mapper.Map(updateDto, category);
            category.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Kategori başarıyla güncellendi.");
        }
    }
}
