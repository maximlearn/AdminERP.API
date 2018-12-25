using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace DataEntities.DbContexts.Interface
{
    interface ITargetDbContext : IDisposable
    {
        IQueryable<TEntity> DbSet<TEntity>() where TEntity : class, new();
        void Save();
        void AddEntity<TEntity>(TEntity eModel) where TEntity : class, new();
        void Delete<TEntity>(Expression<Func<TEntity, bool>> expr) where TEntity : class;
        void Delete<TEntity>(IEnumerable<TEntity> toDelete) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void AttachEntity<TEntity>(TEntity entity) where TEntity : class, new();
        void AddRange(IEnumerable<object> entities);
        void UpdateEntity<TEntity>(TEntity eModel) where TEntity : class, new();

    }
}
