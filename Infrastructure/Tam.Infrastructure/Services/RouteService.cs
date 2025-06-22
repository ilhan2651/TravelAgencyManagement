using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.RouteDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class RouteService(
        IRouteRepository routeRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork) : IRouteService
    {
        public async Task<ServiceResult> CreateAsync(CreateRouteDto createDto)
        {
            var route = mapper.Map<Route>(createDto);
            route.CreatedAt = DateTime.UtcNow;

            await routeRepository.AddAsync(route);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Rota başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<List<RouteListDto>>> GetAllAsync()
        {
            var routes = await routeRepository.GetRoutes()
                .ProjectTo<RouteListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return routes.Any()
                ? ServiceResult<List<RouteListDto>>.Ok(routes)
                : ServiceResult<List<RouteListDto>>.Fail("Hiçbir rota bulunamadı.");
        }

        public async Task<ServiceResult<RouteDetailDto>> GetByIdAsync(int id)
        {
            var route = await routeRepository.GetRouteWithStopsAsync(id);
            if (route == null)
                return ServiceResult<RouteDetailDto>.Fail("Rota bulunamadı.");

            var dto = mapper.Map<RouteDetailDto>(route);
            return ServiceResult<RouteDetailDto>.Ok(dto);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateRouteDto updateDto)
        {
            var route = await routeRepository.GetByIdAsync(id);
            if (route == null)
                return ServiceResult.Fail("Rota bulunamadı.");

            mapper.Map(updateDto, route);
            route.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Rota başarıyla güncellendi.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var route = await routeRepository.GetByIdAsync(id);
            if (route == null)
                return ServiceResult.Fail("Rota bulunamadı.");

            if (route.DeletedAt != null)
                return ServiceResult.Fail("Rota zaten silinmiş.");

            route.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Rota başarıyla silindi.");
        }
    }
}
