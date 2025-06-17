using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IGuideRepository : IGenericRepository<Guide>
    {
        IQueryable<Guide> GetAllGuides();
        Task<Guide> GetGuideWithDetails(int id);
        IQueryable<Guide> SearchGuides(string searchTerm);
    }
}
