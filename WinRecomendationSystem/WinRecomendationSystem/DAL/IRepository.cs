using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRecomendationSystem.DAL
{
    public interface IRepository<T>
    {
        void Add(T element);
        void Edit(T element);
        T GetByID(int id);
        void Delete(int id);
        IQueryable<T> GetAll();
    }
}
