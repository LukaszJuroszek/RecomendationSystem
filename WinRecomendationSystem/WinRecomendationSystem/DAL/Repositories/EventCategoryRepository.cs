using System;
using System.Collections.Generic;
using WinRecomendationSystem.Model;
namespace WinRecomendationSystem.DAL
{
    public class EventCategoryRepository : IRepository<EventCategory>
    {
        public EventCategoryRepository()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public void Add(EventCategory element)
        {
            throw new NotImplementedException();
        }

        public void Delete(EventCategory element)
        {
            throw new NotImplementedException();
        }

        public void Edit(EventCategory element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public EventCategory GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
