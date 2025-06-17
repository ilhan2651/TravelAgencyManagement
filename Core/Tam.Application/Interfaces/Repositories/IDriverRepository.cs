using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        public IQueryable<Driver> GetAllDrivers();
        public Task<Driver> GetDriverWithTransfersAndTours(int id);
        public IQueryable<Driver> SearchDrivers(string term);

    }
}
