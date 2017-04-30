using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected TicketContext _context;
        protected DbSet<T> _dbSet;
        private bool disposed = false;
        public Repository(TicketContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public virtual void Update(T element)
        {
            _context.Entry(element).State = EntityState.Modified;
        }
        public virtual T GetByID(int id)
        {
            return _dbSet.Find(id);
        }
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
