using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class ViewedTicketEventDateRepository : IRepository<ViewedTicketEventDate>
    {
        public ViewedTicketEventDateRepository()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
        public void Add(ViewedTicketEventDate element)
        {
            throw new NotImplementedException();
        }

        public void Delete(ViewedTicketEventDate element)
        {
            throw new NotImplementedException();
        }

        public void Edit(ViewedTicketEventDate element)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ViewedTicketEventDate> GetAll()
        {
            throw new NotImplementedException();
        }
        public ViewedTicketEventDate GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
