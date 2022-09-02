using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.BulkOperations;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(int id);
        void Add(TEntity entity);
        void BulkAdd(List<TEntity> entity, Action<BulkOperation>? options);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void BulkDelete(List<TEntity> entity, Action<BulkOperation>? options);
    }
}
