using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface ILanguageRepository : IGenericRepository<Language>
    {
        IQueryable<Language> GetAllLanguages();
    }
}
