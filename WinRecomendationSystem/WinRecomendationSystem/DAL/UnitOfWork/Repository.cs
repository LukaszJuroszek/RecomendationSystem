using System;
using System.Collections.Generic;
using System.Data.Entity;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected TicketContext _context;
        protected DbSet<T> dbSet;
        public Repository(TicketContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public virtual T GetByID(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        //IDisposable implementation
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                   _context.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
