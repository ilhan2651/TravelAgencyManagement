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
    public class CategoryRepository(TamDbContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
        public async Task<List<Category>> GetAllCategories()
        {
            return await context.Categories
                .OrderByDescending(c => c.DeletedAt == null)
                .ToListAsync();
        }
        
    }
}
