using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        IQueryable<Route> GetRoutes();
        Task<Route?> GetRouteWithStopsAsync(int id);
    }
}
