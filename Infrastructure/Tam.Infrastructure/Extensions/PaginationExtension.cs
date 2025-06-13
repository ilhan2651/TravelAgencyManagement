using AutoMapper;
using Tam.Application.Dtos.Common;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Tam.Infrastructure.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PagedResult<TDestination>> ProjectToPagedResultAsync<TSource,TDestination>(
            this IQueryable<TSource> query,
            IConfigurationProvider configuration,
            int page,
            int pageSize)
        {
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TDestination>(configuration)
                .ToListAsync();

            return new PagedResult<TDestination>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}