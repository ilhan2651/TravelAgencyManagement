using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        IQueryable<Discount> GetAllDiscounts();
    }

}
