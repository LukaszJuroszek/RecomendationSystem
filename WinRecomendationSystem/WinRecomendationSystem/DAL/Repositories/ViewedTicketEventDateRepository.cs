using System;
using System.Collections.Generic;
using System.Linq;
using WinRecomendationSystem.Model;

namespace WinRecomendationSystem.DAL
{
    public class ViewedTicketEventDateRepository : Repository<ViewedTicketEventDate>
    {
        public ViewedTicketEventDateRepository(TicketContext context) : base(context) { }
        public override void Add(ViewedTicketEventDate element)
        {
            throw new NotImplementedException();
        }
        public override void Delete(ViewedTicketEventDate element)
        {
            throw new NotImplementedException();
        }
        public override void Edit(ViewedTicketEventDate element)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<ViewedTicketEventDate> GetAll()
        {
            throw new NotImplementedException();
        }
        public override ViewedTicketEventDate GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
