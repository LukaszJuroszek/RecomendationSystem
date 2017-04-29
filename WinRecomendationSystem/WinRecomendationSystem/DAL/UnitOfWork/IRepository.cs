using System.Collections.Generic;

namespace WinRecomendationSystem.DAL
{
    public interface IRepository<T>  where T : class
    {
        void Add(T element);
        void Edit(T element);
        T GetByID(int id);
        void Delete(T element);
        IEnumerable<T> GetAll();
    }
}
