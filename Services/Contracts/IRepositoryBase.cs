using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void AddMultiple(List<T> entities);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> CheckExists(Expression<Func<T, bool>> expression);
        bool SaveChanges();
    }
}
