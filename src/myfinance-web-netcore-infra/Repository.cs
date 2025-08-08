using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore_domain.Entities;
using myfinance_web_netcore_domain.Entities.Base;
using myfinance_web_netcore_infra.Interfaces.Base;
using System.Collections.Generic;

namespace myfinance_web_netcore_infra
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;
        protected Repository(DbContext dbContext) 
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            var entity = new TEntity() { Id = id };
            _context.Attach(entity);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public TEntity Get(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Post(TEntity entity)
        {
            if (entity.Id == null)
            {
                _dbSet.Add(entity);
            }
            else
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }
    }
}
