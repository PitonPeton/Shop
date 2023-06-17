using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace shop.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(TEntity[] entities);
        void Update(TEntity entity);
        void Update(TEntity[] entities);
        void Delete(TEntity entity);
        void Delete(TEntity[] entities);
        TEntity GetEntity(int id);
        List<TEntity> GetEntities();
        bool Exists(Expression<Func<TEntity, bool>>filter);
        void SaveChanges();
    }
}
