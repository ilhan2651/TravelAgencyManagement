using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Language;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class LanguageService(
        ILanguageRepository languageRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : ILanguageService
    {
        public async Task<ServiceResult> CreateAsync(CreateLanguageDto createDto)
        {
            var language = mapper.Map<Language>(createDto);
            language.CreatedAt = DateTime.UtcNow;

            await languageRepository.AddAsync(language);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Dil başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<List<LanguageListDto>>> GetAllAsync()
        {
            var languages = await languageRepository.GetAllLanguages().ToListAsync();
            if (!languages.Any())
                return ServiceResult<List<LanguageListDto>>.Fail("Dil bulunamadı.");

            var result = mapper.Map<List<LanguageListDto>>(languages);
            return ServiceResult<List<LanguageListDto>>.Ok(result);
        }

        public async Task<ServiceResult<LanguageListDto>> GetByIdAsync(int id)
        {
            var language = await languageRepository.GetByIdAsync(id);
            if (language == null)
                return ServiceResult<LanguageListDto>.Fail("Dil bulunamadı.");

            var dto = mapper.Map<LanguageListDto>(language);
            return ServiceResult<LanguageListDto>.Ok(dto);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateLanguageDto updateDto)
        {
            var language = await languageRepository.GetByIdAsync(id);
            if (language == null)
                return ServiceResult.Fail("Dil bulunamadı.");

            mapper.Map(updateDto, language);
            language.UpdatedAt = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Dil başarıyla güncellendi.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var language = await languageRepository.GetByIdAsync(id);
            if (language == null)
                return ServiceResult.Fail("Dil bulunamadı.");

            if (language.DeletedAt != null)
                return ServiceResult.Fail("Dil zaten silinmiş.");

            language.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Dil başarıyla silindi.");
        }
    }
}