using drones_api.Data;
using drones_api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private DronesApiContext DbContext;

        public RepositoryBase(DronesApiContext context)
        {
            DbContext = context;
        }

        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
                DbContext.Set<T>()
                .AsNoTracking() : DbContext.Set<T>();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
                DbContext.Set<T>()
                .Where(expression)
                .AsNoTracking() : DbContext.Set<T>().Where(expression);

        public void Update(T entity) => DbContext.Set<T>().Update(entity);
        public void AddMultiple(List<T> entities) => DbContext.AddRange(entities: entities);
        public T Add(T entity) { DbContext.Set<T>().Add(entity); SaveChanges(); return entity; }

        public async Task<bool> CheckExists(Expression<Func<T, bool>> expression) => await DbContext.Set<T>().AnyAsync(expression);
        public bool SaveChanges() => DbContext.SaveChanges() >= 0 ? true : false;
    }
}
