using System;
using System.Linq;
using System.Linq.Expressions;

namespace WinRecomendationSystem.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity element);
        IQueryable<TEntity> All();
        void Update(TEntity element);
        void Delete(TEntity element);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
