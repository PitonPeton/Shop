using Microsoft.EntityFrameworkCore;
using shop.Domain;
using shop.Domain.Repository;
using shop.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace shop.Infraestructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly shopContext shop;
        private readonly DbSet<TEntity> entities;
        public BaseRepository(shopContext shop) 
        { 
            this.shop = shop;
            this.entities = this.shop.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.entities.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Add(TEntity[] entities)
        {
            this.entities.AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {

            this.entities.Remove(entity);
        }

        public virtual void Delete(TEntity[] entities)
        {
            this.entities.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.entities.UpdateRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.shop.SaveChanges();
        }

    }
}
