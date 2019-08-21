using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyStore.Data;

namespace MyStore.Repository
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext contextd;
        public Repository(ApplicationDbContext _context)
        {
            contextd = _context;
        }
        public void Add(TEntity entity)
        {
            contextd.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            contextd.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return contextd.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return contextd.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return contextd.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            contextd.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            contextd.Set<TEntity>().RemoveRange(entities);
        }

    }
}
