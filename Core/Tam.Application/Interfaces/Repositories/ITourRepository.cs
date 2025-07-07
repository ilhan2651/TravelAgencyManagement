using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface ITourRepository : IGenericRepository<Tour>
    {
        IQueryable<Tour> GetAllTours();
        Task<Tour?> GetTourWithDetailsAsync(int id);
        IQueryable<Tour> SearchTours(string term);
    }
}