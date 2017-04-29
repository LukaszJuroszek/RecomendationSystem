using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
   public class TicketEventRepository : IRepository<TicketEvent>
    {
        public TicketEventRepository()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public void Add(TicketEvent element)
        {
            throw new NotImplementedException();
        }


        public void Delete(TicketEvent element)
        {
            throw new NotImplementedException();
        }

        public void Edit(TicketEvent element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketEvent> GetAll()
        {
            using (var db =new TicketContext())
            {
                return db.TicketEvents.Select(x=>x);
            }
        }

        public TicketEvent GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
