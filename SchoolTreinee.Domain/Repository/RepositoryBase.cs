using SchoolTreinee.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using SchoolTreinee.Domain.Context;
using SchoolTreinee.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SchoolTreinee.Domain.Repository
{
    //font::http://appetere.com/post/passing-include-statements-into-a-repository
    //https://stackoverflow.com/questions/5376421/ef-including-other-entities-generic-repository-pattern
    //How to use
    //https://stackoverflow.com/questions/21355934/eager-load-all-by-default-with-entity-framework-within-a-generic-repository

    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly SchoolContext _context;
        private DbSet<TEntity> _dbSet;

        public RepositoryBase(SchoolContext context)
        {
            _context = context;
            _dbSet   = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                (_dbSet, (current, expression) => current.Include(expression));
        }

        public virtual TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (_dbSet, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(s => s.ID == id);
            }

            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        private bool _dispose = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_dispose)
                if (disposing)
                {
                    _context.Dispose();
                }

            _dispose = true;
        }
    }
}
