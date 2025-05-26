using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TamDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TamDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async ValueTask AddAsync(T entity)=> await _dbSet.AddAsync(entity);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)=>_dbSet.AnyAsync(predicate);         
        public Task<int> CountAsync(Expression<Func<T, bool>> predicate)=> _dbSet.CountAsync(predicate);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public IQueryable<T> GetAll()=>_dbSet.AsQueryable().AsNoTracking();
        public ValueTask<T?> GetByIdAsync(int id)=> _dbSet.FindAsync(id);
        public void Update(T entity) => _dbSet.Update(entity);
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)=>_dbSet.Where(predicate).AsNoTracking();
        
        
    }
}
