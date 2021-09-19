using Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Abstraction
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, IEntity
    {
        Task<TEntity> Get(long id);

        Task<List<TEntity>> Get();

        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(long id);

        Task<List<TEntity>> DeleteRange(List<TEntity> TEntities);

        Task<List<TEntity>> FromSqlRaw(string sql, params object[] parameters);

        Task<object> WrapInTransaction(Func<Task<object>> func);
    }
}