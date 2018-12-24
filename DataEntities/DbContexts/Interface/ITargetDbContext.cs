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

    }
}
