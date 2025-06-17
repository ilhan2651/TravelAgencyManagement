using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class LanguageRepository(TamDbContext context)
        : GenericRepository<Language>(context), ILanguageRepository
    {
        public IQueryable<Language> GetAllLanguages()
        {
            return context.Languages
                .OrderByDescending(l => l.DeletedAt == null)
                .ThenBy(l => l.Name);
        }
    }
}