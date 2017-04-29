using System;
using System.Collections.Generic;
using WinRecomendationSystem.Model;
namespace WinRecomendationSystem.DAL
{
    public class EventCategoryRepository : Repository<EventCategory>
    {
        public EventCategoryRepository(TicketContext context) : base(context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public override void Add(EventCategory element)
        {
            throw new NotImplementedException();
        }

        public override void Delete(EventCategory element)
        {
            throw new NotImplementedException();
        }

        public override void Edit(EventCategory element)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<EventCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public override EventCategory GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
