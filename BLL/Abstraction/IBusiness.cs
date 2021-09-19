using Entities.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Abstraction
{
    public interface IBusiness<TEntity> where TEntity : BaseEntity, IEntity
    {
        Task<TEntity> Get(long id);

        Task<List<TEntity>> Get();

        Task<List<TEntity>> Get(string propertyName, string propertyValue);

        Task<List<TEntity>> Get(string property1Name, string property1Value, string property2Name, string property2Value);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(long id, TEntity entity);

        Task<TEntity> Delete(long id);

        Task<List<TEntity>> DeleteRange(List<TEntity> entities);
    }
}