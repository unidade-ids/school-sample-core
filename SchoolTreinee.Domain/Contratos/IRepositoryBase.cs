using SchoolTreinee.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SchoolTreinee.Domain.Contratos
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includeExpressions);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions);
    }
}
