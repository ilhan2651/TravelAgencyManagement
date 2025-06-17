using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Aprantee;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class AppranteeService(IMapper mapper, IAppranteeRepository appranteeRepository, IUnitOfWork unitOfWork) : IAppranteeService
    {
        public async Task<ServiceResult> CreateAsync(CreateAppranteeDto createApprenteeDto)
        {
            var entity = mapper.Map<Apprantee>(createApprenteeDto);
            entity.CreatedAt = DateTime.UtcNow;
            await appranteeRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Apprantee başarıyla oluşturuldu");
        }

        public async Task<ServiceResult<List<ListAppranteeDto>>> GetAllActiveAsync()
        {
            var apprantees = await appranteeRepository.GetActiveAppranties();
            var result = mapper.Map<List<ListAppranteeDto>>(apprantees);
            return ServiceResult<List<ListAppranteeDto>>.Ok(result);
        }

        public async Task<ServiceResult<List<ListAppranteeDto>>> GetAllPassiveAsync()
        {
            var apprantees = await appranteeRepository.GetPassiveAppranties();
            var result = mapper.Map<List<ListAppranteeDto>>(apprantees);
            return ServiceResult<List<ListAppranteeDto>>.Ok(result);
        }

        public async Task<ServiceResult<ListAppranteeDto>> GetByIdAsync(int id)
        {
            var apprantee = await appranteeRepository.GetByIdAsync(id);
            if (apprantee == null)
                return ServiceResult<ListAppranteeDto>.Fail("Apprantee bulunamadı");
            var dto = mapper.Map<ListAppranteeDto>(apprantee);
            return ServiceResult<ListAppranteeDto>.Ok(dto);
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var entity = await appranteeRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Apprantee bulunamadı");
            if (entity.DeletedAt != null)
                return ServiceResult.Fail("Apprantee zaten silinmiş");
            entity.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Apprantee başarıyla silindi");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateAppranteeDto updateApprenteeDto)
        {
            var entity = await appranteeRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Apprantee bulunamadı");
            mapper.Map(updateApprenteeDto, entity);
            entity.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Apprantee başarıyla güncellendi");
        }
    }
}
