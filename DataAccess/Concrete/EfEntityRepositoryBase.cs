using DataAccess.Abstract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Z.BulkOperations;

namespace DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Add(entity);
                context.SaveChanges();
            }
        }

        public void BulkAdd(List<TEntity> entity, Action<BulkOperation>? options)
        {
            using (var context = new TaskContext())
            {
                context.BulkInsert(entity, options);
            }
        }

        public void BulkDelete(List<TEntity> entity, Action<BulkOperation>? options)
        {
            using (var context = new TaskContext())
            {
                context.BulkDelete(entity, options);
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
    }
}