using System;
using System.Linq;

namespace WinRecomendationSystem.DAL
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T element);
        IQueryable<T> GetAll();
        void Update(T element);
        void Delete(T element);
        T GetByID(int id);
    }
}
