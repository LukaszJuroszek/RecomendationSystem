using System;
using System.Collections.Generic;
using System.Data.Entity;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected TicketContext _context;

        //DbSet usable with any of our entity types
        protected DbSet<T> dbSet;

        //constructor taking the database context and getting the appropriately typed data set from it
        public Repository(TicketContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        //Implementation of IRepository methods
        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> GetAll()
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
            {
                if (disposing)
                {
                   _context.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
