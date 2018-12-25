using DataEntities.DbContexts.Interface;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataEntities.DbContexts
{
    public class ITargetDbContext : DbContext, Interface.ITargetDbContext
    {
        private readonly IConnectionString connectionString;

        public ITargetDbContext(IConnectionString _connectionString)
        {
            this.connectionString = _connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString.TargetDatabaseConnectionString);
        }

        IQueryable<TEntity> Interface.ITargetDbContext.DbSet<TEntity>()
        {
            return Set<TEntity>();
        }

        void Interface.ITargetDbContext.Save()
        {
            SaveChanges();
        }

        void Interface.ITargetDbContext.AddEntity<TEntity>(TEntity entity)
        {
            Add(entity);
        }

        void Interface.ITargetDbContext.AddRange(IEnumerable<object> entities)
        {
            AddRange(entities);
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> expr) where TEntity : class
        {
            Set<TEntity>().RemoveRange(Set<TEntity>().Where(expr));
        }

        public void Delete<TEntity>(IEnumerable<TEntity> toDelete) where TEntity : class
        {
            Set<TEntity>().RemoveRange(toDelete);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Remove(entity);
        }

        public void AttachEntity<TEntity>(TEntity entity) where TEntity : class, new()
        {
            Attach(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.RegisterEntitiesConfigurationFromAssemblyOfType<EntityBase>();
        }

        public override int SaveChanges()
        {
            return SaveChangesCommon();
        }

        private int SaveChangesCommon()
        {

            return base.SaveChanges();
        }

        void Interface.ITargetDbContext.UpdateEntity<TEntity>(TEntity entity)
        {
            Update(entity);
        }

    }
}
