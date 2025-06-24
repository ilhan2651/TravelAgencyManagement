using Tam.Domain.Entities;
using Tam.Application.Interfaces.Repositories;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class DiscountRepository(TamDbContext context)
        : GenericRepository<Discount>(context), IDiscountRepository
    {
        public IQueryable<Discount> GetAllDiscounts()
        {
            return context.Discounts
                .OrderByDescending(x => x.DeletedAt == null)
                .ThenBy(x=>x.Name);
        }
    }
}
