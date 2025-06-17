using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class SupplierRepository(TamDbContext context) : GenericRepository<Supplier>(context), ISupplierRepository
    {
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            return await context.Suppliers
                .Include(s=>s.Vehicles)
                .Include(s=>s.Drivers)
                .OrderByDescending(x=>x.DeletedAt==null)
                .ThenBy(s=>s.Name)
                .ToListAsync();
        }

        public IQueryable<Supplier> SearchSuppliers(string term)
        {
            term = term.Trim().ToLower();
            return context.Suppliers
                .Where(s => s.Name.ToLower().Contains(term) ||
                           s.ContactPerson.ToLower().Contains(term) ||
                           s.PhoneNumber.Contains(term));
        }
    }
}
