﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RecomendationModel.Model;

namespace RecomendationModel.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TicketContext _context;
        public Repository(TicketContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            _context = context;
        }
        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public virtual IQueryable<TEntity> All()
        {
            return _context.Set<TEntity>();
        }
        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return All().Where(predicate);
        }
        public virtual void Update(TEntity element)
        {
            _context.Entry(element).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
